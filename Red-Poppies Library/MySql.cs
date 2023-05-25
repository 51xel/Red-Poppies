using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Text.RegularExpressions;

namespace Red_Poppies_Library {
    public class Holidaymakers {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Type_of_room { get; set; }
        public int Number_of_room { get; set; }
        public DateTime Date { get; set; }
    }

    public class Workers {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }


    public class MySQL : DbContext {
        private string _configFilePath = "config.txt";

        public DbSet<Holidaymakers> Holidaymakers { get; set; }
        public DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (File.Exists(_configFilePath)) {
                string fileContents = File.ReadAllText(_configFilePath);

                string ipPattern = @"#IP:\s*([^\n\r]+)";
                string userPattern = @"#USER:\s*([^\n\r]+)";
                string passwordPattern = @"#PASSWORD:\s*([^\n\r]+)";
                string portPattern = @"#PORT:\s*([^\n\r]+)";
                string databasePattern = @"#DATABASE:\s*([^\n\r]+)";

                string ipAddress = GetMatch(fileContents, ipPattern);
                string username = GetMatch(fileContents, userPattern);
                string password = GetMatch(fileContents, passwordPattern);
                string port = GetMatch(fileContents, portPattern);
                string database = GetMatch(fileContents, databasePattern);

                if (ipAddress != null && username != null && password != null && port != null && database != null) {
                    optionsBuilder.UseMySql($"server={ipAddress};user={username};password={password};database={database};port={port}",
                    new MySqlServerVersion(new Version(8, 0, 33)));
                }
            }
        }

        private string GetMatch(string input, string pattern) {
            Match match = Regex.Match(input, pattern);
            if (match.Success) {
                return match.Groups[1].Value.Trim();
            }
            return null;
        }
    }
}
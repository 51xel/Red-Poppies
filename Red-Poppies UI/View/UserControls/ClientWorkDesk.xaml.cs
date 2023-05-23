using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Red_Poppies_UI.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClientWorkDesk.xaml
    /// </summary>
    public partial class ClientWorkDesk : UserControl
    {
        struct Person
        {
            public string Name { get; set; }
            public string NumberOfRoom { get; set; }
            public string Type { get; set; }
            public string Pay { get; set; }
            public string Days { get; set; }
            public string Date { get; set; }
        }
        public ClientWorkDesk()
        {
            InitializeComponent();

            List.Items.Add(new Person { Name = "Anton", NumberOfRoom = "1", Type = "Luxe", Pay = "123", Days="14", Date="12.12.12"});
        }
    }
}

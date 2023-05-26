using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Poppies_Library {
    public class HolidaymakersToView : Holidaymakers {
        public int Days { get; set; }
        public double Pay { get; set; }
    }

    public class ViewList {
        private static HolidaymakersToView Convert(Holidaymakers holidaymakers) {
            var item = new HolidaymakersToView {
                ID = holidaymakers.ID,
                Name = holidaymakers.Surname + " " + holidaymakers.Name,
                Type_of_room = holidaymakers.Type_of_room,
                Number_of_room = holidaymakers.Number_of_room,
                Date = holidaymakers.Date,
                Days = (DateTime.Now - holidaymakers.Date).Days,
                Pay = (DateTime.Now - holidaymakers.Date).Days * (holidaymakers.Type_of_room == "Luxe" ? 630 : 290)
            };

            return item;
        }

        public static HolidaymakersToView GetClientList(Holidaymakers holidaymakers) {
            return Convert(holidaymakers);
        }

        public static List<HolidaymakersToView> GetClientList(List<Holidaymakers> holidaymakers) {
            var list = new List<HolidaymakersToView>();

            foreach (var element in holidaymakers) {
                list.Add(Convert(element));
            }

            return list;
        }
    }
}

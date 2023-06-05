using Red_Poppies_Library;

namespace Red_Poppies.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void ConvertTest() {
            var holidaymaker = new Holidaymakers { 
                ID = 1,
                Name = "Anton",
                Surname = "Rud",
                Number_of_room = 1,
                Type_of_room = "Luxe",
                Date = DateTime.Now
            };

            var expected = new HolidaymakersToView {
                ID = 1,
                Name = "Rud Anton",
                Surname = null,
                Number_of_room = 1,
                Type_of_room = "Luxe",
                Date = DateTime.Now,
                Days = 0,
                Pay = 0
            };

            var result = ViewList.GetClientList(holidaymaker);

            Assert.AreEqual(expected.ID, result.ID);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Surname, result.Surname);
            Assert.AreEqual(expected.Number_of_room, result.Number_of_room);
            Assert.AreEqual(expected.Type_of_room, result.Type_of_room);
            Assert.AreEqual(expected.Date.ToString(), result.Date.ToString());
            Assert.AreEqual(expected.Days, result.Days);
            Assert.AreEqual(expected.Pay, result.Pay);
        }

        [TestMethod]
        public void WriteToWordTest() {
            Assert.IsTrue(!WriteToWord.WriteToFile(null, null));
        }
    }
}
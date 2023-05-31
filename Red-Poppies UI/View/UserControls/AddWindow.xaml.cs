using Red_Poppies_Library;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Red_Poppies_UI.View.UserControls {
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : UserControl {
        public AddWindow() {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);
            var toAdd = true;

            if (String.IsNullOrWhiteSpace(TextBoxName.Text)) {
                ChangeBorderShadow(TextBoxName, Colors.Red);
                toAdd = false;
            }
            if (String.IsNullOrWhiteSpace(TextBoxSurname.Text)) {
                ChangeBorderShadow(TextBoxSurname, Colors.Red);
                toAdd = false;
            }
            if (String.IsNullOrWhiteSpace(TextBoxTypeOfRoom.Text) || (TextBoxTypeOfRoom.Text != "Standart" && TextBoxTypeOfRoom.Text != "Luxe")) {
                ChangeBorderShadow(TextBoxTypeOfRoom, Colors.Red);
                toAdd = false;
            }
            if (String.IsNullOrWhiteSpace(TextBoxNumberOfRoom.Text)) {
                ChangeBorderShadow(TextBoxNumberOfRoom, Colors.Red);
                toAdd = false;
            }
            if (String.IsNullOrWhiteSpace(TextBoxDate.Text)) {
                ChangeBorderShadow(TextBoxDate, Colors.Red);
                toAdd = false;
            }

            if (toAdd) {
                var client= win.MySQL.Holidaymakers.FirstOrDefault(el => (el.Name == TextBoxName.Text) && el.Surname == TextBoxSurname.Text);

                if (client == null) {
                    DateTime dateTime;
                    if (DateTime.TryParse(TextBoxDate.Text, out dateTime)) {
                        int numberOfRoom;
                        if (int.TryParse(TextBoxNumberOfRoom.Text, out numberOfRoom)) {
                            var clientToAdd = new Holidaymakers {
                                Name = TextBoxName.Text,
                                Surname = TextBoxSurname.Text,
                                Type_of_room = TextBoxTypeOfRoom.Text,
                                Number_of_room = numberOfRoom,
                                Date = dateTime
                            };
                            win.MySQL.Holidaymakers.Add(clientToAdd);

                            win.MySQL.SaveChanges();

                            win.WorkerWorkDesk.List.List.ItemsSource = ViewList.GetClientList(win.MySQL.Holidaymakers.ToList());

                            CancelButton_Click(sender, e);
                        }
                        else {
                            ChangeBorderShadow(TextBoxNumberOfRoom, Colors.Red);
                        }
                    }
                    else {
                        ChangeBorderShadow(TextBoxDate, Colors.Red);
                    }
                }
                else {
                    ChangeBorderShadow(TextBoxName, Colors.Red);
                    ChangeBorderShadow(TextBoxSurname, Colors.Red);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            ChangeBorderShadow(TextBoxName);
            ChangeBorderShadow(TextBoxSurname);
            ChangeBorderShadow(TextBoxTypeOfRoom);
            ChangeBorderShadow(TextBoxNumberOfRoom);
            ChangeBorderShadow(TextBoxDate);

            Visibility = Visibility.Hidden;

            win.WorkerWorkDesk.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxName)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Ім'я";
                    break;
                }
            }
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxSurname)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Прізвище";
                    break;
                }
            }
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxTypeOfRoom)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Тип кімнати";
                    break;
                }
            }
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxNumberOfRoom)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Номер кімнати";
                    break;
                }
            }
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxDate)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Дата";
                    break;
                }
            }
        }

        private void ChangeBorderShadow(DependencyObject depObj, Color? color = null) {
            if (color != null) {
                foreach (var element in Utils.Helper.FindVisualChildren<Border>(depObj)) {
                    if (element.Name == "border") {
                        element.BitmapEffect = new DropShadowBitmapEffect {
                            Color = color.Value,
                            ShadowDepth = 0
                        };
                        break;
                    }
                }
            }
            else {
                foreach (var element in Utils.Helper.FindVisualChildren<Border>(depObj)) {
                    if (element.Name == "border") {
                        element.BitmapEffect = null;
                        break;
                    }
                }
            }
        }
    }
}

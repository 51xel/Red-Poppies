using Red_Poppies_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Red_Poppies_UI.View.UserControls
{
    public partial class WorkerLog : UserControl {
        public WorkerLog() {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            if (!String.IsNullOrWhiteSpace(TextBoxName.Text) && 
                !String.IsNullOrWhiteSpace(TextBoxPassword.Text)) {
                var result = win.MySQL.Workers.ToList().FirstOrDefault(el => ((el.Surname + " " + el.Name) == TextBoxName.Text) && (el.Password == TextBoxPassword.Text));

                if (result != null) {
                    Visibility = Visibility.Hidden;

                    win.WorkerWorkDesk.List.List.ItemsSource = ViewList.GetClientList(win.MySQL.Holidaymakers.ToList());

                    win.WorkerWorkDesk.Visibility = Visibility.Visible;
                }
                else {
                    foreach (var element in Utils.Helper.FindVisualChildren<Border>(TextBoxName)) {
                        if (element.Name == "border") {
                            element.BitmapEffect = new DropShadowBitmapEffect {
                                Color = Colors.Red,
                                ShadowDepth = 0
                            };
                            break;
                        }
                    }
                    foreach (var element in Utils.Helper.FindVisualChildren<Border>(TextBoxPassword)) {
                        if (element.Name == "border") {
                            element.BitmapEffect = new DropShadowBitmapEffect {
                                Color = Colors.Red,
                                ShadowDepth = 0
                            };
                            break;
                        }
                    }
                }
            }
        }

        private void WorkerLog_Loaded(object sender, RoutedEventArgs e) {
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxName)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Введіть прізвище та ім'я";
                    break;
                }
            }
            foreach (var element in Utils.Helper.FindVisualChildren<TextBlock>(TextBoxPassword)) {
                if (element.Name == "PlaceHolderText") {
                    element.Text = "Введіть пароль";
                    break;
                }
            }

        }
    }
}

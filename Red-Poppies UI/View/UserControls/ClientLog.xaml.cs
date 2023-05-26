using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Red_Poppies_Library;

namespace Red_Poppies_UI.View.UserControls
{
    public partial class ClientLog : UserControl{
        public ClientLog(){
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            if (!String.IsNullOrWhiteSpace(NameAndSurname.Text)) {
                var result = win.MySQL.Holidaymakers.ToList().FirstOrDefault(el => (el.Surname + " " + el.Name) == NameAndSurname.Text);
                
                if (result != null) {
                    Visibility = Visibility.Hidden;
                    win.ClientWorkDesk.Visibility = Visibility.Visible;
                    win.ClientWorkDesk.List.List.Items.Add(ViewList.GetClientList(result));
                }
                else {
                    foreach (var element in Utils.Helper.FindVisualChildren<Border>(NameAndSurname)) {
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
    }
}

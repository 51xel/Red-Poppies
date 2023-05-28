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

namespace Red_Poppies_UI.View.UserControls {
    public partial class WorkerWorkDesk : UserControl {
        public WorkerWorkDesk() {
            InitializeComponent();
        }

        private void Change_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            if (!win.ToChange) {
                win.ToAdd = false;
                win.ToDelete = false;

                win.ToChange = true;

                SetModeColor(Colors.Transparent, Colors.Orange);
            }
            else {
                win.ToChange = false;
                SetModeColor(Colors.Transparent, Colors.Transparent);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            if (!win.ToDelete) {
                win.ToChange = false;
                win.ToAdd = false;

                win.ToDelete = true;

                SetModeColor(Colors.Transparent, Colors.Red);
            }
            else {
                win.ToDelete = false;
                SetModeColor(Colors.Transparent, Colors.Transparent);
            }
            
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            win.ToChange = false;
            win.ToDelete = false;

            win.ToAdd = true;

            Visibility = Visibility.Hidden;
            win.AddWindow.Visibility = Visibility.Visible;
        }

        public void SetModeColor(Color from, Color to) {
            ModeColor.Background = new LinearGradientBrush {
                EndPoint = new Point(0.5, 1),
                StartPoint = new Point(0.5, 0),
                GradientStops = { new GradientStop(from, 0), new GradientStop(to, 1) }
            };
        }
    }
}

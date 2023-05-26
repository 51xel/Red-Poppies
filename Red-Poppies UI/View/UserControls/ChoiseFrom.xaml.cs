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
    public partial class ChoiseFrom : UserControl {
        public ChoiseFrom() {
            InitializeComponent();
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            Visibility = Visibility.Hidden;
            win.ClientLog.Visibility = Visibility.Visible;
        }

        private void WorkerButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            Visibility = Visibility.Hidden;
            win.WorkerLog.Visibility = Visibility.Visible;
        }
    }
}

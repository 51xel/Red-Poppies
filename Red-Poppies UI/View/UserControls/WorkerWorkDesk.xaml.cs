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

            win.ToAdd = false;
            win.ToDelete = false;

            win.ToChange = true;
        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            win.ToChange = false;
            win.ToAdd = false;

            win.ToDelete = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            win.ToChange = false;
            win.ToDelete = false;

            win.ToAdd = true;
        }
    }
}

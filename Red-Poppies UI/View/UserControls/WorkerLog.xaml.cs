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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Red_Poppies_UI.View.UserControls
{
    public partial class WorkerLog : UserControl {
        public WorkerLog() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

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

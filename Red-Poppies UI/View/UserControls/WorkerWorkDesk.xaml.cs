using Red_Poppies_Library;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                win.ToPrint = false;

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
                win.ToPrint = false;

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
            win.ToPrint = false;

            win.ToAdd = true;

            Visibility = Visibility.Hidden;
            win.AddWindow.Visibility = Visibility.Visible;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e) {
            var win = (MainWindow)Window.GetWindow(this);

            if (!win.ToPrint) {
                win.ToChange = false;
                win.ToDelete = false;
                win.ToAdd = false;

                win.ToPrint = true;
                SetModeColor(Colors.Transparent, Colors.Blue);
            }
            else if(win.ListToPrint.Count == 0){
                win.ToPrint = false;
                SetModeColor(Colors.Transparent, Colors.Transparent);
            }
            else {
                WriteToWord.WriteToFile(win.ListToPrint, "word.docx");

                win.ListToPrint.Clear();

                win.WorkerWorkDesk.List.List.ItemsSource = ViewList.GetClientList(win.MySQL.Holidaymakers.ToList());

                win.ToPrint = false;
                SetModeColor(Colors.Transparent, Colors.Transparent);
            }
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

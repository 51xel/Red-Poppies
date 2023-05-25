using Red_Poppies_UI.Utils;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Red_Poppies_Library;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Red_Poppies_UI {
    public partial class MainWindow : Window {
        public MySQL MySQL { get; set; }
        public MainWindow() {
            InitializeComponent();
            WinMax.DoSourceInitialized(this);
        }

        private void Window_StateChanged(object sender, EventArgs e) {
            if (WindowState == WindowState.Maximized) {
                Uri uri = new Uri("/Images/Icons/restore.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                TitlebarButtons.MaximizeButtonImage.Source = imgSource;
            }
            else if (WindowState == WindowState.Normal) {
                Uri uri = new Uri("/Images/Icons/maximize.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                TitlebarButtons.MaximizeButtonImage.Source = imgSource;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e) {
            ChoiseForm.Visibility = Visibility.Visible;

            MySQL = new MySQL();

            await CheckConnect();
        }

        private async Task CheckConnect() {
            try {
                if (await MySQL.Database.CanConnectAsync()) {
                    await MySQL.Database.OpenConnectionAsync();

                    ChoiseForm.ClientButton.IsEnabled = true;
                    ChoiseForm.WorkerButton.IsEnabled = true;

                    ChoiseForm.ClientButton.Opacity = 1;
                    ChoiseForm.WorkerButton.Opacity = 1;
                }
            }catch (Exception ex) {}
        }
    }
}

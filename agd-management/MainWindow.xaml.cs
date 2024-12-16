using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace agd_management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string selected_device = string.Empty;
        string selected_radio_content = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckDeviceConnection(object sender, RoutedEventArgs e)
        {
            if (select_device.Text == "Odkurzacz")
            {
                device_img.Source = new BitmapImage(new Uri("img/odkurzacz.jpg", UriKind.RelativeOrAbsolute));
                device_conn_message.Content = "Device connected";
                device_conn_message.Foreground = Brushes.Green;

                selected_device = select_device.Text;

                AddSettingsOptions();
            }
            if (select_device.Text == "Pralka")
            {
                device_img.Source = new BitmapImage(new Uri("img/pralka.jpg", UriKind.RelativeOrAbsolute));
                device_conn_message.Content = "Device connected";
                device_conn_message.Foreground = Brushes.Green;
                
                selected_device = select_device.Text;

                AddSettingsOptions();
            }
        }

        private void AddSettingsOptions()
        {
            device_settings.Children.Clear();
            string[] washing_machine_sett = ["Bawełna", "Syntetyki", "Delikatne"];

            string[] vaacum_sett = ["Odkurzanie na sucho", "Odkurzanie na mokro", "Tryb cichy"];

            if (!string.IsNullOrEmpty(selected_device) && 
                selected_device == "Pralka")
            {
                for (int i = 0;  i < washing_machine_sett.Length ; i++) 
                {
                    var settings_radio = new RadioButton
                    {
                        Content = washing_machine_sett[i],
                        GroupName = "settings",
                        Margin = new Thickness(0, 0, 0, 10),
                    };

                    settings_radio.Checked += SetRadioButtonContent;
                    device_settings.Children.Add(settings_radio);
                }

            } 
            else if (!string.IsNullOrEmpty(selected_device) &&
                selected_device == "Odkurzacz")
            {
                for (int i = 0; i < vaacum_sett.Length; i++)
                {
                    var settings_radio = new RadioButton
                    {
                        Content = vaacum_sett[i],
                        GroupName = "settings",
                        Margin = new Thickness(0, 0, 0, 10),
                    };

                    settings_radio.Checked += SetRadioButtonContent;
                    device_settings.Children.Add(settings_radio);
                }

            }
        }

        private void SetRadioButtonContent(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                string selectedSetting = radioButton.Content.ToString();
                selected_radio_content = selectedSetting;
            }
        }

        private void DisplaySettings(object sender, RoutedEventArgs e)
        {
            string startHour = start_hour.Text;

            string mess = $"Wybrane urządzenie: {selected_device} \n" +
                $"Ustawienia: {selected_radio_content}\n" +
                $"Godzina rozpoczęcia {startHour}";

            MessageBox.Show(mess, "Alert", MessageBoxButton.OK);
        }
    }
}
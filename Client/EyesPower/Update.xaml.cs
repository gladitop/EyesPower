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
using System.Windows.Shapes;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {

        public Update()
        {
            InitializeComponent();

            lbversion.Content = $"Версия программы: {Data.version}";
        }

        private async void btupdate_Click(object sender, RoutedEventArgs e)//Обновление
        {
            await CheckUpdate();
        }

        public async Task CheckUpdate()
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(new Action(async () =>
                {
                    try
                    {
                        WebClient web = new WebClient();
                        btupdate.IsEnabled = false;
                        web.DownloadProgressChanged += web_ProgressChanged;
                        string versoin = web.DownloadString("https://raw.githubusercontent.com/damiralmaev/ACraftC/master/Update/version.txt");
                        if (versoin == Data.version)
                        {
                            MessageBox.Show(versoin + " " + Data.version);
                            btupdate.IsEnabled = true;
                            MessageBox.Show("У вас последния версия!", "EysePower: Центр обновлений", MessageBoxButton.OK, MessageBoxImage.Information);
                            Thread.Sleep(0);
                        }
                        else
                        {
                            MessageBoxResult lol = MessageBox.Show($"Найдина новая версия! Новая версия: {versoin}. Обновиться?", "EysePower: Центр обновлений", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (lol == MessageBoxResult.Yes)
                            {
                                await web.DownloadFileTaskAsync("https://raw.githubusercontent.com/damiralmaev/ACraftC/master/Update/EyesPower.exe",
                                    $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/EysePowerNew.exe");
                                MessageBoxResult lol1 = MessageBox.Show("Новая версия программы скачана! Запустить?", "EysePower: Центр обновлений",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Information);

                                if (lol1 == MessageBoxResult.Yes)
                                {
                                    Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/EyesPower", true);
                                    Process.Start($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/EysePowerNew.exe");
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                Thread.Sleep(0);
                            }
                        }

                    }
                    catch (Exception ex) { MessageBox.Show($"Ошибка обновление: {ex.Message}", "EysePower: Центр обновлений", MessageBoxButton.OK, MessageBoxImage.Error); }
                }));
            });
        }

        private void web_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressdow.Value = e.ProgressPercentage;
        }
    }
}

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
using System.IO;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public WebClient web = new WebClient();

        public Update()
        {
            InitializeComponent();

            lbversion.Content = $"Версия программы: {Data.version}";
        }

        private void btupdate_Click(object sender, RoutedEventArgs e)//Обновление
        {
            Thread thread = new Thread(new ThreadStart(CheckUpdate));
            thread.Start();
        }

        public void CheckUpdate()
        {
            try
            {
                this.Dispatcher.Invoke(new Action(() => {
                    string versoin = web.DownloadString("");
                    if (versoin == Data.version)
                    {
                        MessageBox.Show("У вас последния версия!", "EysePower: Центр обновлений", MessageBoxButton.OK, MessageBoxImage.Information);
                        Thread.Sleep(0);
                    }
                    else
                    {
                        MessageBoxResult lol = MessageBox.Show("Найдина новая версия! Обновиться?", "EysePower: Центр обновлений", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (lol == MessageBoxResult.Yes)
                        {
                            web.DownloadProgressChanged += web_ProgressChanged;
                            web.DownloadFile("", $"{Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)}/EysePower");
                            MessageBoxResult lol1 = MessageBox.Show("Новая версия программы скачана! Запустить?", "EysePower: Центр обновлений",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Information);

                            if (lol1 == MessageBoxResult.Yes)
                            {

                            }
                        }
                        else
                        {
                            Thread.Sleep(0);
                        }
                    }
                }));
            }
            catch { MessageBox.Show("Ошибка обновление", "EysePower: Центр обновлений", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void web_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressdow.Value = e.ProgressPercentage;
        }
    }
}

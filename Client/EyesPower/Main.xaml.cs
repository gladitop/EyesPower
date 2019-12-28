using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EyesPower.Properties;// и да это для удобства

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()//Загразка формы
        {
            InitializeComponent();

            //проверка состояние
            //настройка

            CheckState();
            if (Settings.Default.Update == true)
            {
                Thread thread = new Thread(new ThreadStart(CheckUpdate));
                thread.Start();
            }
        }

        public void CheckUpdate()
        {
            try
            {
                WebClient web = new WebClient();
                string versoin = web.DownloadString("https://raw.githubusercontent.com/damiralmaev/ACraftC/master/Update/version.txt");
                if (versoin != Data.version)
                {
                    MessageBox.Show($"Найдена новая версия! Новая версия: {versoin}\n" +
                        $"Передите в центр обновлений!", "EyesPower: Основное", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch {  }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//при закрытие
        {
            Environment.Exit(0);
        }

        public void CheckState()//проверка состояние
        {
            //настройка

            if (Data.UpdateCustomizationing == false)
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/statebad.png"));
                lbcustomization.Visibility = Visibility.Visible;
                btsetting.Visibility = Visibility.Visible;
                NoSettings.Visibility = Visibility.Visible;
                btstarttraning.Visibility = Visibility.Collapsed;
                lbstate.Content = "Состояние: Плохое";
            }
            else
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/stategood.png"));
                lbcustomization.Visibility = Visibility.Collapsed;
                btsetting.Visibility = Visibility.Collapsed;
                NoSettings.Visibility = Visibility.Collapsed;
                btstarttraning.Visibility = Visibility.Visible;
                lbstate.Content = "Состояние: Отличное";
            }

            if (Settings.Default.Customization == false)
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/statebad.png"));
                lbcustomization.Visibility = Visibility.Visible;
                btsetting.Visibility = Visibility.Visible;
                NoSettings.Visibility = Visibility.Visible;
                btstarttraning.Visibility = Visibility.Collapsed;
                lbstate.Content = "Состояние: Плохое";
            }
            else
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/stategood.png"));
                lbcustomization.Visibility = Visibility.Collapsed;
                btsetting.Visibility = Visibility.Collapsed;
                NoSettings.Visibility = Visibility.Collapsed;
                btstarttraning.Visibility = Visibility.Visible;
                lbstate.Content = "Состояние: Отличное";
            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)//горячие клавиши
        {
            if (e.Key == Key.F1)
            {
                About about = new About();
                about.ShowDialog();
            }
        }

        private void btsetting_Click(object sender, RoutedEventArgs e)//Настройка
        {
            Customizationing customizationing = new Customizationing();
            customizationing.ShowDialog();
            CheckState();
        }

        private void btstarttraning_Click(object sender, RoutedEventArgs e)//Начать тренировку
        {
            StartTraning startTraning = new StartTraning();
            startTraning.ShowDialog();
        }

        private void btsettings_Click(object sender, RoutedEventArgs e)//Настройки
        {
            if (Settings.Default.Customization == true)
            {
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пройдите настройку!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btaccount_Click(object sender, RoutedEventArgs e)//Аккаунт
        {
            if (Settings.Default.Customization == true)
            {
                Account account = new Account();
                account.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пройдите настройку!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btupdate_Click(object sender, RoutedEventArgs e)//Обновление
        {
            Update update = new Update();
            update.ShowDialog();
        }

        private void NoSettings_Click(object sender, RoutedEventArgs e)//Без настроек
        {
            MessageBoxResult lol = MessageBox.Show("Вы уверены?", Title, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (lol == MessageBoxResult.Yes)
            {
                Settings.Default.Autoload = true;
                Settings.Default.Customization = true;
                Settings.Default.Program = true;
                Settings.Default.Training = true;
                Settings.Default.Update = true;
                Settings.Default.YesHelp = true;
                NoSettings.Visibility = Visibility.Collapsed;
                Settings.Default.Save();
                CheckState();
            }
        }
    }
}

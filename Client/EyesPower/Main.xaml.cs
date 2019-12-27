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
                btstarttraning.Visibility = Visibility.Collapsed;
                lbstate.Content = "Состояние: Плохое";
            }
            else
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/stategood.png"));
                lbcustomization.Visibility = Visibility.Collapsed;
                btsetting.Visibility = Visibility.Collapsed;
                btstarttraning.Visibility = Visibility.Visible;
                lbstate.Content = "Состояние: Отличное";
            }

            if (Settings.Default.Customization == false)
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/statebad.png"));
                lbcustomization.Visibility = Visibility.Visible;
                btsetting.Visibility = Visibility.Visible;
                btstarttraning.Visibility = Visibility.Collapsed;
                lbstate.Content = "Состояние: Плохое";
            }
            else
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/stategood.png"));
                lbcustomization.Visibility = Visibility.Collapsed;
                btsetting.Visibility = Visibility.Collapsed;
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
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void btaccount_Click(object sender, RoutedEventArgs e)//Аккаунт
        {
            Account account = new Account();
            account.ShowDialog();
        }
    }
}

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
            if (Settings.Default.Customization == false)
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/statebad.png"));
                lbcustomization.Visibility = Visibility.Visible;
                btsetting.Visibility = Visibility.Visible;
                lbstate.Content = "Состояние: Плохое";
            }
            else
            {
                imagesstate.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Resources/stategood.png"));
                lbcustomization.Visibility = Visibility.Collapsed;
                btsetting.Visibility = Visibility.Collapsed;
                lbstate.Content = "Состояние: Отличное";
            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                About about = new About();
                about.ShowDialog();
            }
        }
    }
}

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
using EyesPower.Properties;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для InputControl.xaml
    /// </summary>
    public partial class InputControl : Page
    {
        public InputControl()
        {
            InitializeComponent();
        }

        private void btinput_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.PassworldControl == lbpass.Password)
            {
                MessageBox.Show("Пароль верный!", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                Data.number = 2;
                Data.NewPage = true;
            }
            else
            {
                MessageBox.Show("Пароль неверный!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

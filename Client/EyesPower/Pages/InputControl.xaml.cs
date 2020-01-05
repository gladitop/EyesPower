using EyesPower.Properties;
using System.Windows;
using System.Windows.Controls;

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

using EyesPower.Properties;
using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomControl.xaml
    /// </summary>
    public partial class WelcomControl : Page
    {
        public WelcomControl()
        {
            InitializeComponent();
        }

        private void btactivate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lbpass.Password))
            {
                MessageBox.Show("Видите пароль!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                lbpass.Password = "";
                lbrepeatpass.Password = "";
            }
            else if (string.IsNullOrWhiteSpace(lbrepeatpass.Password))
            {
                MessageBox.Show("Повторите пароль!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                lbrepeatpass.Password = "";
                lbpass.Password = "";
            }
            else if (lbpass.Password != lbrepeatpass.Password)
            {
                MessageBox.Show("Пароли не совпадают!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                lbrepeatpass.Password = "";
            }
            else
            {
                Settings.Default.StartControl = true;
                Settings.Default.PassworldControl = lbpass.Password;
                Settings.Default.Save();
                Data.number = 2;
                Data.NewPage = true;
            }
        }
    }
}

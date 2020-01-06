using EyesPower.Properties;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для NoAccount.xaml
    /// </summary>
    public partial class NoAccount : Page
    {
        public NoAccount()
        {
            InitializeComponent();
        }

        private void btinput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult lol = MessageBox.Show("Внимание при этом выборе удалиться вся ваша информация!", "EyesPower: Ваш аккаунт",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (lol == MessageBoxResult.Yes)
            {
                Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/EyesPower", true);
                Settings.Default.Reset = true;
                Settings.Default.ResetExit = false;
                Settings.Default.LoginReset = true;
                Settings.Default.Save();
                EyesPower.Data.ExitLogin = true;
            }
            else
            {
                MessageBox.Show("Не бугайте меня так!", "EyesPower: Ваш аккаунт",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnew_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult lol = MessageBox.Show("Внимание при этом выборе удалиться вся ваша информация!", "EyesPower: Ваш аккаунт",
    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (lol == MessageBoxResult.Yes)
            {
                Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/EyesPower", true);
                Settings.Default.Reset = true;
                Settings.Default.ResetExit = false;
                Settings.Default.LoginReset = false;
                Settings.Default.Save();
                EyesPower.Data.ExitLogin = true;
            }
            else
            {
                MessageBox.Show("Не бугайте меня так!", "EyesPower: Ваш аккаунт",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

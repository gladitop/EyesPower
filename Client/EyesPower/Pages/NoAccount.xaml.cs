using EyesPower.Properties;
using Microsoft.Win32;
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
                EyesPower.Data.ExitLogin = true;
                Settings.Default.Save();
                try
                {
                    string ExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string name = "EysepPower";
                    RegistryKey reg;
                    reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                    reg.DeleteValue(name);
                    reg.Close();
                }
                catch
                { }
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
                EyesPower.Data.ExitLogin = true;
                Settings.Default.Save();
                try
                {
                    string ExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
                    string name = "EysepPower";
                    RegistryKey reg;
                    reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                    reg.DeleteValue(name);
                    reg.Close();
                }
                catch
                { }
            }
            else
            {
                MessageBox.Show("Не бугайте меня так!", "EyesPower: Ваш аккаунт",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

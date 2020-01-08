using EyesPower.Properties;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для YesAccount.xaml
    /// </summary>
    public partial class YesAccount : Page
    {
        public YesAccount()
        {
            InitializeComponent();

            //вставка значений

            lblogin.Content = $"Логин: {Settings.Default.Login}";
            lbpassworld.Content = $"Пароль: {Settings.Default.Passworld}";
        }

        private void btexit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult lol = MessageBox.Show("Внимание при этом выборе удалиться вся ваша информация!", "EyesPower: Ваш аккаунт",
    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (lol == MessageBoxResult.Yes)
            {
                Directory.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}/EyesPower", true);
                Settings.Default.Reset = false;
                Settings.Default.ResetExit = true;
                Settings.Default.LoginReset = true;
                Settings.Default.Save();
                EyesPower.Data.ExitLogin = true;
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

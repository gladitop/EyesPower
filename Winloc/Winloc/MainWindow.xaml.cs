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
using System.IO;
using System.Security.Cryptography;

namespace Winloc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pass = "";
        public bool Closing = false;

        public MainWindow()
        {
            InitializeComponent();
            pass = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt");
        }

        private void btpass_Click(object sender, RoutedEventArgs e)
        {
            var md5create = MD5.Create();
            var md5 = md5create.ComputeHash(Encoding.UTF8.GetBytes(lbpass.Password));

            if (pass == Convert.ToBase64String(md5))
            {
                MessageBox.Show("Пароль верный!", "Уря!", MessageBoxButton.OK, MessageBoxImage.Information);
                Closing = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль неверный!", "Нееее!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Closing == true)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}

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

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnotakk_Click(object sender, RoutedEventArgs e)// без аккаунта
        {
            MessageBoxResult answer = MessageBox.Show($"Внимание без аккаунта вы не сможете использовать сихронизацию!\nВы уверены что хотите без аккаунта использовать это приложение?", Title, MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (answer == MessageBoxResult.Yes)
            {
                Settings.Default.Account = false;
                Settings.Default.Login = "Login";
                Settings.Default.Passworld = "Passworld";
                Settings.Default.Save();
                Main m = new Main();
                m.Show();
                this.Hide();
            }
        }

        private void btaccountyes_Click(object sender, RoutedEventArgs e)// с аккаунтом
        {
            AccountInput f = new AccountInput();
            f.ShowDialog();
        }

        private void btaccountinput_Click(object sender, RoutedEventArgs e)
        {
            AccountNew f = new AccountNew();
            f.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

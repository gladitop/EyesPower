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
                Settings.Default.StartProgram = true;
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
            if (Data.ExitMain == true)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        private void btaccountinput_Click(object sender, RoutedEventArgs e)//При аккаунте (регистер)
        {
            AccountNew f = new AccountNew();
            f.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//закрытие проги
        {
            Environment.Exit(0);
        }

        private void mainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                About about = new About();
                about.ShowDialog();
            }
        }
    }
}

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
using System.Net;
using System.Net.Sockets;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для AccountNew.xaml
    /// </summary>
    public partial class AccountNew : Window
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public AccountNew()
        {
            InitializeComponent();
        }

        private void btnewaccount_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbemail.Text))
            {
                MessageBox.Show("Видите email! Без email нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbpass.Password))
            {
                MessageBox.Show("Видите пароль! Без пароля нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tbpass.Password.Length < 8)
            {
                MessageBox.Show("Пароль слишком короткий!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tbpass.Password == "12345678")
            {
                MessageBox.Show(@"Думаю пароль 12345678 не очень безопасен", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tbpass.Password != tbpassreplay.Password)
            {
                MessageBox.Show("Ваш пароль не одинаковый", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    client.Connect("127.0.0.1", 904);
                    client.Send(Encoding.UTF8.GetBytes("EysePower 1.0"));
                    Task.Delay(100).Wait();
                    client.Send(Encoding.UTF8.GetBytes("Reg"));
                    Task.Delay(10).Wait();
                    client.Send(Encoding.UTF8.GetBytes(tbemail.Text));
                    Task.Delay(10).Wait();
                    client.Send(Encoding.UTF8.GetBytes(tbpass.Password));
                    СonfirmationEmail email = new СonfirmationEmail();
                    Data.client = client;
                    email.ShowDialog();
                    if (Data.ExitNewAccount == true)
                    {
                        Main main = new Main();
                        main.Show();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    client.Close();
                    Data.client.Close();
                    MessageBox.Show($"Ошибка! {ex.Message}", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

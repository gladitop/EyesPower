using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для AccountNew.xaml
    /// </summary>
    public partial class AccountNew : Window
    {
        private Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        public bool Pass = false;//Показ пароля

        public AccountNew()
        {
            InitializeComponent();
        }

        private void btnewaccount_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbemail.Text))
            {
                MessageBox.Show("Видете email! Без email нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbpass.Password))
            {
                MessageBox.Show("Видете пароль! Без пароля нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
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
                    Data.email = tbemail.Text;
                    Data.passworld = tbpass.Password;
                    Data.client = client;
                    email.ShowDialog();
                    if (Data.ExitNewAccount == true)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    client.Close();
                    Data.client.Close();
                    MessageBox.Show($"Ошибка! {ex.Message}", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btpass_Click(object sender, RoutedEventArgs e)//Показать пароль
        {
            if (string.IsNullOrWhiteSpace(tbpass.Password))
                MessageBox.Show("Видете пароль! Без пароля нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            else if (string.IsNullOrWhiteSpace(tbpassreplay.Password) == false)
            {
                MessageBox.Show($"Ваш пароль: {tbpass.Password}\n" +
                    $"Повтор пароля: {tbpassreplay.Password}", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Ваш пароль: {tbpass.Password}\n" +
                    $"Повтора пароля нет!", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EyesPower.Properties;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для СonfirmationEmail.xaml
    /// </summary>
    public partial class СonfirmationEmail : Window
    {
        private static byte[] buffer = new byte[1024];

        public СonfirmationEmail()
        {
            InitializeComponent();
        }

        private void btsend_Click(object sender, RoutedEventArgs e)
        {

            Socket client = Data.client;
            client.Send(Encoding.UTF8.GetBytes(btcode.Text));
            Task.Delay(100).Wait();
            int i = client.Receive(buffer);
            Task.Delay(100).Wait();
            if (Encoding.UTF8.GetString(buffer, 0, i) == "Yes")
            {

                if (string.IsNullOrWhiteSpace(btcode.Text))
                {
                    MessageBox.Show("Нужен код!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    Task.Delay(100).Wait();
                    i = client.Receive(buffer);
                    string lol = Encoding.UTF8.GetString(buffer, 0, i);
                    MessageBox.Show(lol);
                    if (lol == "Yes")
                    {
                        MessageBox.Show("Ваш аккаунт зарегистрирован!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
                        Settings.Default.Account = true;
                        Settings.Default.Login = Data.email;
                        Settings.Default.Passworld = Data.passworld;
                        Settings.Default.StartProgram = true;
                        Settings.Default.Save();
                        Data.ExitNewAccount = true;
                        this.Close();
                    }
                    else if (lol == "No")
                    {
                        MessageBox.Show("Ошибка: код не подходит!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }
            else if (Encoding.UTF8.GetString(buffer, 0, i) == "No")
            {
                MessageBox.Show("Ошибка: email уже использовался!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}

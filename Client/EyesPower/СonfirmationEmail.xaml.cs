using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            MessageBox.Show(Encoding.UTF8.GetString(buffer, 0, i));
            if (Encoding.UTF8.GetString(buffer, 0, i) == "Yes")
            {
                Task.Delay(100).Wait();
                MessageBox.Show(Encoding.UTF8.GetString(buffer, 0, i));
                if (Encoding.UTF8.GetString(buffer, 0, i) == "Yes")
                {
                    MessageBox.Show("Ваш аккаунт зарегистрирован!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else if (Encoding.UTF8.GetString(buffer, 0, i) == "No")
                {
                    MessageBox.Show("Ошибка: код не подходит!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (Encoding.UTF8.GetString(buffer, 0, i) == "No")
            {
                MessageBox.Show("Ошибка: email уже использовался!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}

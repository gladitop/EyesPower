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
using System.Threading;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для СonfirmationEmail.xaml
    /// </summary>
    public partial class СonfirmationEmail : Window
    {
        static byte[] buffer = new byte[1024];

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

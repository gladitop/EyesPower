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
            Data.client.Send(Encoding.UTF8.GetBytes(btcode.Text));
            Task.Delay(10).Wait();
            int i = Data.client.Receive(buffer);
            if (Encoding.UTF8.GetString(buffer, 0, i) == "Yes")
            {
                MessageBox.Show("Ваш аккаунт зарегистрирован!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Ошибка: код не подходит!", "EyesPower: Новый аккаунт", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

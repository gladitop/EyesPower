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
using System.Net.Sockets;
using System.Net;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для AccountInput.xaml
    /// </summary>
    public partial class AccountInput : Window
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] buffer = new byte[1024];

        public AccountInput()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btinput_Click(object sender, RoutedEventArgs e)//Вход
        {
            if (string.IsNullOrWhiteSpace(tbemail.Text))
            {
                MessageBox.Show("Без email нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbpass.Password))
            {
                MessageBox.Show("Без пароля нельзя!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    client.Connect("127.0.0.1", 904);
                    Task.Delay(30).Wait();
                    client.Send(Encoding.UTF8.GetBytes("EysePower 1.0"));
                    Task.Delay(30).Wait();
                    client.Send(Encoding.UTF8.GetBytes("Log"));
                    Task.Delay(30).Wait();
                    client.Send(Encoding.UTF8.GetBytes(tbemail.Text));
                    Task.Delay(30).Wait();
                    client.Send(Encoding.UTF8.GetBytes(tbpass.Password));
                    int i = client.Receive(buffer);
                    if (Encoding.UTF8.GetString(buffer, 0, i) == "Login Yes")
                    {
                        MessageBox.Show("Вход удался!", "EyesPower: Вход", MessageBoxButton.OK, MessageBoxImage.Information);
                        client.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не найдено аккаунта!", "EyesPower: Вход", MessageBoxButton.OK, MessageBoxImage.Error);
                        client.Disconnect(true);
                        client.Close();
                    }
                }
                catch { }
            }
        }
    }
}

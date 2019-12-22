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
            else {
                


            }
        }
    }
}

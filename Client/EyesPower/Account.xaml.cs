using EyesPower.Properties;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();
            if (Settings.Default.Account == false)
            {
                frame.Navigate(new Pages.NoAccount());
            }
            else if (Settings.Default.Account == true)
            {
                frame.Navigate(new Pages.YesAccount());
            }
        }

        public void Update()
        {
            new Thread(() =>
            {
                while (true)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        Task.Delay(10).Wait();
                        if (Pages.Data.ExitLogin == true)
                        {
                            Settings.Default.Reset = true;
                            MessageBox.Show("kjk");
                            Settings.Default.Save();
                            this.Close();
                        }
                    }));
                }
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}

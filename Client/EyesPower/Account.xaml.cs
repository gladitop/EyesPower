using EyesPower.Properties;
using System;
using System.Threading;
using System.Windows;

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
            while (true)
            {
                Thread.Sleep(10);
                Dispatcher.Invoke(new Action(() =>
                {
                    if (EyesPower.Data.ExitLogin == true)
                    {
                        Settings.Default.Reset = true;
                        Settings.Default.Save();
                        this.Close();
                    }
                }));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }
    }
}

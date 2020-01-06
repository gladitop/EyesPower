using EyesPower.Properties;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Control.xaml
    /// </summary>
    public partial class Control : Window
    {
        public Control()
        {
            InitializeComponent();
            frame.Navigate(new Pages.WelcomControl());
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        public void Update()
        {
            Pages.Data.NewPage = true;
            while (true)
            {
                Task.Delay(10).Wait();
                if (Pages.Data.number == 2 && Pages.Data.NewPage == true)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.SettingsControl());
                    }));
                }
                else if (Settings.Default.StartControl == true && Pages.Data.NewPage == true)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.InputControl());
                    }));
                }
                Pages.Data.NewPage = false;
            }
        }
    }
}

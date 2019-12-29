using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            while (true)
            {
                Task.Delay(10).Wait();
                if (Pages.Data.number == 2 && Pages.Data.NewPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.SettingsControl());
                    }));
                }
            }
        }
    }
}

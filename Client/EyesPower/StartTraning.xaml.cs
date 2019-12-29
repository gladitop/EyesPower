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
using System.Threading;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для StartTraning.xaml
    /// </summary>
    public partial class StartTraning : Window
    {
        public StartTraning()
        {
            InitializeComponent();
            frame.Navigate(new Pages.WelcomTraning());
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        public void Update()
        {
            while (true)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    if (Pages.Data.number == 2 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.TrainingCircle());
                    }

                    if (Pages.Data.number == 3 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.TrainingClosing());
                    }
                }));
            }
        }
    }
}

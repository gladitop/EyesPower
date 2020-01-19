using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для StartTraning.xaml
    /// </summary>
    public partial class StartTraning : Window
    {
        public object contect;

        public StartTraning()
        {
            InitializeComponent();
        }

        public void Update()
        {
            //bool whiles = true;
            while(true)
            {
                Task.Delay(10).Wait();
                Dispatcher.Invoke(new Action(() =>
                {
                    if (Pages.Data.number == 2 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        contect = new Pages.TrainingCircle();
                        frame.Navigate(contect);
                        MessageBox.Show("1");
                    }

                    if (Pages.Data.number == 3 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.TrainingClosing());
                    }

                    if (Pages.Data.number == 4 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.TraningWindow());
                    }

                    if (Pages.Data.number == 5 && Pages.Data.NewPage == true)
                    {
                        Pages.Data.NewPage = false;
                        frame.Navigate(new Pages.PicturesTraning());
                    }

                    if (Pages.Data.exit == true)
                    {
                        //Settings.Default.TraningQuantity += 1;
                        //Settings.Default.Save();
                        //whiles = false;
                        Pages.Data.exit = false;
                        Thread.Sleep(0);
                        this.Close();
                    }
                }));
            }
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            contect = new Pages.WelcomTraning();
            frame.Navigate(contect);
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }
    }
}

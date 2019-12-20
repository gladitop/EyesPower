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
    /// Логика взаимодействия для Customizationing.xaml
    /// </summary>
    public partial class Customizationing : Window
    {
        public Customizationing()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();

            frame.Navigate(new Pages.Welcome());
        }

        public void Update()
        {
            while (true)
            {
                Task.Delay(10).Wait();

                //проверка выхода
                if (Pages.Data.exit == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        Pages.Data.exit = false;
                        this.Close();
                    }));
                }

                if (Pages.Data.numberanswer == 2 && Pages.Data.NewPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.SendAndHelp());
                        Pages.Data.NewPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 3)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.CheckUpdate());
                        Pages.Data.NewPage = false;
                    }));
                }
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Customizationing.xaml
    /// </summary>
    public partial class Customizationing : Window
    {
        public bool exit = false;//выход

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
                        exit = true;
                        this.Close();
                    }));
                }

                if (Pages.Data.numberanswer == 1 && Pages.Data.BackPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.Welcome());
                        Pages.Data.BackPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 2 && Pages.Data.BackPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.SendAndHelp());
                        Pages.Data.BackPage = false;
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

                if (Pages.Data.numberanswer == 3 && Pages.Data.BackPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.CheckUpdate());
                        Pages.Data.BackPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 4 && Pages.Data.BackPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.Programs());
                        Pages.Data.BackPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 3 && Pages.Data.NewPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.CheckUpdate());
                        Pages.Data.NewPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 4 && Pages.Data.NewPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.Programs());
                        Pages.Data.NewPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 5 && Pages.Data.NewPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.Training());
                        Pages.Data.NewPage = false;
                    }));
                }
            }
        }

        public void discharge()//сброс (переменных)
        {
            Pages.Data.BackPage = false;
            Pages.Data.NewPage = false;
            Pages.Data.exit = false;
            Pages.Data.numberanswer = 1;
            Pages.Data.yesHelp = false;
        }

        private void customizationing_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (exit == true)
            {
                e.Cancel = false;
            }
            else if (exit == false)
            {
                e.Cancel = true;
                MessageBoxResult lol = MessageBox.Show("Если вы хотите закрыть это окно, то все ваши настройки будут сброшаны", "EysePower: Настройка", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (lol == MessageBoxResult.Yes)
                {
                    e.Cancel = false;//прикол)
                    discharge();
                }
            }
        }
    }
}

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
                        frame.Navigate(new Pages.SendAndHelp());
                        Pages.Data.BackPage = false;
                    }));
                }

                if (Pages.Data.numberanswer == 4 && Pages.Data.BackPage == true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        frame.Navigate(new Pages.CheckUpdate());
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

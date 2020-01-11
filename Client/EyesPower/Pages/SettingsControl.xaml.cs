using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using EyesPower.Properties;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : Page
    {
        private Time.tamer tamer = new Time.tamer();

        public SettingsControl()
        {
            InitializeComponent();

            if (Settings.Default.ControlWinloc == true)
            {
                checkblocking.IsChecked = true;
                checkwarning.IsChecked = false;
            }
            else
            {
                checkblocking.IsChecked = false;
                checkwarning.IsChecked = true;
            }
        }

        private void lbHour_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        public void Update()
        {
            while (true)
            {
                Task.Delay(10).Wait();

                EyesPower.Data.timer = tamer;
            }
        }

        private void btsave_Click(object sender, RoutedEventArgs e)//Сохранить
        {
            tamer.Embed("123", Convert.ToInt32(lbHour.Text), Convert.ToInt32(lbMinutes.Text), Convert.ToInt32(lbSecond.Text));

            if (checkblocking.IsChecked.Value == true)
            {
                Settings.Default.ControlWinloc = true;
            }
            else if (checkwarning.IsChecked.Value == true)
            {
                Settings.Default.ControlWinloc = false;
            }

            Settings.Default.Save();
            EyesPower.Data.timer = tamer;
            tamer.Start();
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        private void checkwarning_Checked(object sender, RoutedEventArgs e)
        {
            if (checkwarning.IsChecked.Value == true)
            {
                checkblocking.IsChecked = false;
            }
        }

        private void checkblocking_Checked(object sender, RoutedEventArgs e)
        {
            if (checkblocking.IsChecked.Value == true)
            {
                checkwarning.IsChecked = false;
            }
        }
    }
}

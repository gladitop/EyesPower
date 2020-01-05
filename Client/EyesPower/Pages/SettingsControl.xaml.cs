using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : Page
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public SettingsControl()
        {
            InitializeComponent();
        }

        private void lbHour_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void btsave_Click(object sender, RoutedEventArgs e)//Сохранить
        {
            if (checkblocking.IsChecked.Value == true)
            {
                MessageBox.Show("lol");
                Time.tamer tamer = new Time.tamer();
                tamer.Embed("123", Convert.ToInt32(lbHour.Text), Convert.ToInt32(lbMinutes.Text), Convert.ToInt32(lbSecond.Text));
                tamer.Start();
            }
        }

    }
}

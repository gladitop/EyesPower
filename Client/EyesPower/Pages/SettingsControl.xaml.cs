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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

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

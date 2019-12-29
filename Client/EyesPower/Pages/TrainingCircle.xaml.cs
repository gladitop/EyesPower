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

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для TrainingCircle.xaml
    /// </summary>
    public partial class TrainingCircle : Page
    {
        public TrainingCircle()
        {
            InitializeComponent();
        }

        public void Lol()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                lb.Visibility = Visibility.Collapsed;
                media.Visibility = Visibility.Visible;
                media.Play();
                media.MediaEnded += Media_MediaEnded;
            }));
        }

        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            Data.number = 3;
            Data.NewPage = true;
        }

        private void trainingcircle_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Lol));
            thread.Start();
        }
    }
}

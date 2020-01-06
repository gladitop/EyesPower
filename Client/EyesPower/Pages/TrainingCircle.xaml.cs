using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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
            Dispatcher.Invoke(new Action(() =>
            {
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

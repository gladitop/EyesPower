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
    /// Логика взаимодействия для TrainingClosing.xaml
    /// </summary>
    public partial class TrainingClosing : Page
    {
        public TrainingClosing()
        {
            InitializeComponent();
        }

        public void Update()
        {
            this.Dispatcher.Invoke(new Action(async () =>
            {
                media.Visibility = Visibility.Visible;
                media.Play();
                media.MediaEnded += Media_MediaEnded;
            }));
        }

        public void Slep()
        {
            Task.Delay(30000).Wait();
            Data.number = 4;
            Data.NewPage = true;
        }

        private void Media_MediaEnded(object sender, RoutedEventArgs e)
        {
            media.Position = new TimeSpan(0);
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
        }

        private void main_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Update));
            thread.Start();
            Thread thread1 = new Thread(new ThreadStart(Slep));
            thread1.Start();
        }
    }
}

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
            Thread thread = new Thread(new ThreadStart(Exit));
            thread.Start();

            frame.Navigate(new Pages.Welcome());
        }

        public void Exit()
        {
            if (Pages.Data.exit == true)
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    Pages.Data.exit = false;
                    this.Close();
                }));

            }
        }
    }
}

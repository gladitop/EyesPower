using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EyesPower.Properties;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()// при запуске это формы (хотя она скрыта ;) )
        {
            InitializeComponent();
            if (Settings.Default.StartProgram == false)
            {
                MainWindow f = new MainWindow();
                f.Show();
            }
            else
            {
                Main f = new Main();
                f.Show();
            }
            this.Hide();
        }
    }
}

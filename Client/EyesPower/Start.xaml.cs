using EyesPower.Properties;
using System.Windows;

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

using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void btexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

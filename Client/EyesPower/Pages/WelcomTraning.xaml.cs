using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomTraning.xaml
    /// </summary>
    public partial class WelcomTraning : Page
    {
        public WelcomTraning()
        {
            InitializeComponent();
        }
        private void btyes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Следите за шариком!", "EysePower: Тренировка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Data.number = 2;
            Data.NewPage = true;
        }

        private void btno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы уверены?", "EysePower: Тренировка", MessageBoxButton.OK, MessageBoxImage.Question);
        }
    }
}

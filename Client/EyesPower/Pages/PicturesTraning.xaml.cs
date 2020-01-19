using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для PicturesTraning.xaml
    /// </summary>
    public partial class PicturesTraning : Page
    {
        public PicturesTraning()
        {
            InitializeComponent();
        }

        private void btend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы завершили тренировку!", "EysePower: Тренировка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Data.exit = true;
        }
    }
}

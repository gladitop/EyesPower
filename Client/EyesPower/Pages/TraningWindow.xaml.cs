using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для TraningWindow.xaml
    /// </summary>
    public partial class TraningWindow : Page
    {
        public TraningWindow()
        {
            InitializeComponent();
        }

        private void btdone_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Вы завершили тренировку!", "EysePower: Тренировка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //Data.exit = true;

            Data.number = 5;
            Data.NewPage = true;
        }
    }
}

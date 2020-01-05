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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            MessageBox.Show("Вы завершили тренировку!", "EysePower: Тренировка", MessageBoxButton.OK, MessageBoxImage.Warning);
            Data.exit = true;
        }
    }
}

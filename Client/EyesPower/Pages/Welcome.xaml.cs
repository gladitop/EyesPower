using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
            lbnumber.Content = $"{Data.numberanswer}/5";
        }

        private void btyes_Checked(object sender, RoutedEventArgs e)//Кнопка да
        {
            if (Data.numberanswer == 1)
            {
                btnext.IsEnabled = true;
            }

            Data.NewPage = true;
        }

        private void btnext_Click(object sender, RoutedEventArgs e)//Дальше
        {
            if (btyes.IsChecked.Value == true)
            {
                Data.numberanswer = 2;
                Data.NewPage = true;
            }
            else if (btno.IsChecked.Value == true)
            {
                MessageBoxResult lol = MessageBox.Show("При отказе это окно закроется, но вы можете пройди это потом!", "EysePower: Настройка", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (lol == MessageBoxResult.Yes)
                {
                    Data.exit = true;
                }
            }

        }

        private void btno_Checked(object sender, RoutedEventArgs e)//Кнопка нет
        {
            if (Data.numberanswer == 1)
            {
                btnext.IsEnabled = true;
            }
        }
    }
}

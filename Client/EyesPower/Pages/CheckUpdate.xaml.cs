using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для CheckUpdate.xaml
    /// </summary>
    public partial class CheckUpdate : Page
    {
        public CheckUpdate()
        {
            InitializeComponent();
            lbnumber.Content = $"{Data.numberanswer}/5";
            Data.NewPage = false;
        }

        private void btnext_Click(object sender, RoutedEventArgs e)//Далее
        {
            if (btyes.IsChecked.Value == true)
            {
                Data.Update = true;
                Data.NewPage = true;
                Data.numberanswer = 4;
            }
            else if (btno.IsChecked.Value == true)
            {
                Data.numberanswer = 4;
                Data.Update = false;
                Data.NewPage = true;
            }
        }

        private void btback_Click(object sender, RoutedEventArgs e)//Назад
        {
            Data.Update = false;
            Data.numberanswer = 2;
            Data.BackPage = true;
        }

        private void btyes_Checked(object sender, RoutedEventArgs e)//Да
        {
            btnext.IsEnabled = true;
        }

        private void btno_Checked(object sender, RoutedEventArgs e)//Нер
        {
            btnext.IsEnabled = true;
        }
    }
}

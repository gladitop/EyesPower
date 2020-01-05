using System.Windows;
using System.Windows.Controls;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для Programs.xaml
    /// </summary>
    public partial class Programs : Page
    {
        public Programs()
        {
            InitializeComponent();
            lbnumber.Content = $"{Data.numberanswer}/5";
            Data.NewPage = false;
        }

        private void btyes_Checked(object sender, RoutedEventArgs e)
        {
            btnext.IsEnabled = true;
        }

        private void btno_Checked(object sender, RoutedEventArgs e)
        {
            btnext.IsEnabled = true;
        }

        private void btnext_Click(object sender, RoutedEventArgs e)
        {
            if (btyes.IsChecked.Value == true)
            {
                Data.Program = true;
                Data.NewPage = true;
                Data.numberanswer = 5;
            }
            else if (btno.IsChecked.Value == true)
            {
                Data.numberanswer = 5;
                Data.Program = false;
                Data.NewPage = true;
            }
        }

        private void btback_Click(object sender, RoutedEventArgs e)
        {
            Data.Program = false;
            Data.numberanswer = 3;
            Data.BackPage = true;
        }
    }
}

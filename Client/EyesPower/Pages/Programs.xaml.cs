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

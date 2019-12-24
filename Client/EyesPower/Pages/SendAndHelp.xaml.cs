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
    /// Логика взаимодействия для SendAndHelp.xaml
    /// </summary>
    public partial class SendAndHelp : Page
    {
        public SendAndHelp()
        {
            InitializeComponent();
            lbnumber.Content = $"{Data.numberanswer}/5";
            Data.NewPage = false;
        }

        private void btyes_Checked(object sender, RoutedEventArgs e)//Кнопка да
        {
            btnext.IsEnabled = true;
        }

        private void btno_Checked(object sender, RoutedEventArgs e)//Кнопка нет
        {
            btnext.IsEnabled = true;
        }

        private void btnext_Click(object sender, RoutedEventArgs e)//Дальше
        {
            if (btyes.IsChecked.Value == true)
            {
                Data.yesHelp = true;
                Data.NewPage = true;
                Data.numberanswer = 3;
            }
            else if (btno.IsChecked.Value == true)
            {
                Data.numberanswer = 3;
                Data.yesHelp = false;
                Data.NewPage = true;
            }
        }

        private void btback_Click(object sender, RoutedEventArgs e)//Назад
        {
            Data.yesHelp = false;
            Data.numberanswer = 1;
            Data.BackPage = true;
        }
    }
}

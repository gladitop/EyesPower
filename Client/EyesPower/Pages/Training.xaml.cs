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
using EyesPower.Properties;

namespace EyesPower.Pages
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class Training : Page
    {
        public Training()
        {
            InitializeComponent();
            lbnumber.Content = $"{Data.numberanswer}/5";
            Data.NewPage = false;
        }

        private void btnext_Click(object sender, RoutedEventArgs e)
        {
            if (btyes.IsChecked.Value == true)
            {
                Data.Training = true;
            }
            else if (btno.IsChecked.Value == true)
            {
                Data.Training = false;
            }

            //MessageBox.Show($"{Data.Program}, {Data.Training}, {Data.yesHelp}, {Data.Update}");
            MessageBox.Show("Вы успешно закончили настройку!", "EysePower: Настройка", MessageBoxButton.OK, MessageBoxImage.Information);
            Settings.Default.Customization = true;
            EyesPower.Data.Program = Data.Program;
            EyesPower.Data.Training = Data.Training;
            EyesPower.Data.Update = Data.Update;
            EyesPower.Data.yesHelp = Data.yesHelp;
            EyesPower.Data.UpdateCustomizationing = true;
            Settings.Default.Program = Data.Program;
            Settings.Default.Training = Data.Training;
            Settings.Default.Update = Data.Update;
            Settings.Default.YesHelp = Data.yesHelp;
            Settings.Default.Save();
            Data.exit = true;
        }

        private void btback_Click(object sender, RoutedEventArgs e)
        {
            Data.Training = false;
            Data.numberanswer = 4;
            Data.BackPage = true;
        }

        private void btno_Checked(object sender, RoutedEventArgs e)
        {
            btnext.IsEnabled = true;
        }

        private void btyes_Checked(object sender, RoutedEventArgs e)
        {
            btnext.IsEnabled = true;
        }
    }
}

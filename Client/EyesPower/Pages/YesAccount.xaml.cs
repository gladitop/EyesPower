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
    /// Логика взаимодействия для YesAccount.xaml
    /// </summary>
    public partial class YesAccount : Page
    {
        public YesAccount()
        {
            InitializeComponent();

            //вставка значений

            lblogin.Content = Settings.Default.Login;
            lbpassworld.Content = Settings.Default.Passworld;
        }
    }
}

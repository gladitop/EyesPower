using EyesPower.Properties;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();
            if (Settings.Default.Account == false)
            {
                frame.Navigate(new Pages.NoAccount());
            }
            else if (Settings.Default.Account == true)
            {
                frame.Navigate(new Pages.YesAccount());
            }
        }
    }
}

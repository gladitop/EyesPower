using EyesPower.Properties;
using System.Windows.Controls;

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

            lblogin.Content = $"Логин: {Settings.Default.Login}";
            lbpassworld.Content = $"Пароль: {Settings.Default.Passworld}";
        }
    }
}

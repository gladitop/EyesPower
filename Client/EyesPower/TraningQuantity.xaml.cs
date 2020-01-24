using EyesPower.Properties;
using System.Windows;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для TraningQuantity.xaml
    /// </summary>
    public partial class TraningQuantity : Window
    {
        public TraningQuantity()
        {
            InitializeComponent();

            //Загрузка всех параметров!

            lbstattraning.Content = $"Было тренировок: {Settings.Default.TraningQuantity}";
            lbstatstart.Content = $"Программа запущена на пк: {Settings.Default.StartProgramQuantity}";
            lbstatwaring.Content = $"Сколько раз было включено предуждение: {Settings.Default.WaringQuantity}";
        }
    }
}

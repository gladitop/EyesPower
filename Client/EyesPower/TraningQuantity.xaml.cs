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
using EyesPower.Properties;
using System.Windows.Shapes;

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

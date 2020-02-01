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
using System.Windows.Shapes;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для Instruction.xaml
    /// </summary>
    public partial class Instruction : Window
    {
        public Instruction()
        {
            InitializeComponent();
        }

        //private treeview_Selected(object sender, RoutedEventArgs e)
        //{
        //    TreeViewItem tvItem = (TreeViewItem)sender;
        //    MessageBox.Show("Выбран узел: " + tvItem.Header.ToString());
        //}

        private void treeview_Selected(object sender, RoutedEventArgs e)//При выборе элемента
        {
            TreeViewItem tvItem = (TreeViewItem)sender;

            if (tvItem.Header.ToString() == "Что делать если состояние плохое")
            {
                frame.Navigate(new Pages.badstatusin());
            }
            else if (tvItem.Header.ToString() == "У меня не работают настройки")
            {
                frame.Navigate(new Pages.NotWorkSettingsIn());
            }
        }
    }
}

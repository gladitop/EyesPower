using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ProcessAdd.xaml
    /// </summary>
    public partial class ProcessAdd : Window
    {
        public ProcessAdd()
        {
            InitializeComponent();
        }

        private void btprocess_Click(object sender, RoutedEventArgs e)//Добавить процесс
        {
            if (string.IsNullOrWhiteSpace(tbprocess.Text))
            {
                MessageBox.Show("Напишите процесс!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbprocess.Text) != true)
            {
                string lol = tbprocess.Text;

                if (Proverca() == true)
                {
                    Data.Process.Add(lol);
                    Data.SetProcess();
                    MessageBox.Show("Процесс сохранён!", Title, MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    Close();
                }
                else
                {
                    MessageBox.Show("Такой процесс уже есть!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public bool Proverca()//У меня прекрасный English)
        {
            bool yes = true;

            foreach (string proc in Data.Process)
            {
                if (proc == tbprocess.Text)
                    yes = false;
            }

            if (yes == true)
                return true;

            return false;
        }
    }
}

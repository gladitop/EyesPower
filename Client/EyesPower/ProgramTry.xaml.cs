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
using System.Diagnostics;

namespace EyesPower
{
    /// <summary>
    /// Логика взаимодействия для ProgramTry.xaml
    /// </summary>
    public partial class ProgramTry : Window
    {
        public ProgramTry()
        {
            InitializeComponent();

            lbback.Content = "<--";//Прикольчик
            GetProcces();
        }

        public void GetProcces()
        {
            Process[] processes = Process.GetProcesses();
            bool yes = true;

            listprocforward.Items.Clear();
            foreach (Process proc in processes)
            {
                foreach (string lol in Data.Process)
                {
                    if (lol == proc.ProcessName)
                    {
                        MessageBox.Show("1");
                        yes = false;
                    }

                    if(yes == true)
                        listprocforward.Items.Add(proc.ProcessName);
                }
            }
        }

        private void btforward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lol = listprocforward.SelectedItem.ToString();
                Data.Process.Add(lol);
                GetProcces();
            }
            catch
            {
                MessageBox.Show("Нужен процесс!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

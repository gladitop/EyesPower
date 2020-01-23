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
        //public List<string> Pross = new List<string>();

        public ProgramTry()
        {
            InitializeComponent();

            //Data.Process.Clear();
            //Pross.Clear();
            lbback.Content = "<--";//Прикольчик
            Data.GetProcess();
            GetProcces();
        }

        public void Update()//Обновление (тут баг)
        {
            foreach (string lol in Data.Process)
            {
                listprocback.Items.Add(lol);
            }
        }

        public void GetProcces()
        {
            Process[] processes = Process.GetProcesses();
            bool yes = true;

            listprocforward.Items.Clear();
            foreach (Process proc in processes)
            {
                //MessageBox.Show(proc.ProcessName);
                foreach (string lol in Data.Process)//проврка
                {
                    //MessageBox.Show(lol);
                    if (lol == proc.ProcessName || proc.ProcessName == "EyesPower")
                    {
                        //MessageBox.Show("1");
                        yes = false;
                    }
                }
                if (yes == true)
                {
                    listprocforward.Items.Add(proc.ProcessName);
                }
                yes = true;
                Update();
            }
        }

        private void btforward_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lol = listprocforward.SelectedItem.ToString();
                Data.Process.Add(lol);
                GetProcces();
                Update();
            }
            catch
            {
                MessageBox.Show("Нужен процесс!", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btdone_Click(object sender, RoutedEventArgs e)//Применить
        {
            Data.SetProcess();
            GetProcces();
            Update();
        }

        private void ___main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Data.Process.Clear();
        }
    }
}

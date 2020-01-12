using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Winloc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Form1 : Form
    {
        public string pass = "";
        public bool Closing = false;

        public Form1()
        {
            InitializeComponent();
            pass = File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt");
        }

        private void btpass_Click(object sender, EventArgs e)
        {
            var md5create = MD5.Create();
            var md5 = md5create.ComputeHash(Encoding.UTF8.GetBytes(lbpass.Text));

            if (pass == Convert.ToBase64String(md5))
            {
                MessageBox.Show("Пароль верный!", "Уря!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Closing = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль неверный!", "Нееее!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Taskmsg()
        {
            
        }

        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Closing == true)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}

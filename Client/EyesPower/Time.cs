using EyesPower.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    internal static class Time
    {
        public struct tamer
        {
            private int Hour;
            private int Minute;
            private int Second;
            private Thread thread;
            private string Passworld;

            public void StartThread()
            {
                thread.Start();
            }

            [Obsolete]
            public void StopThread()
            {
                thread.Suspend();
            }

            public int TimeHour()
            {
                return Hour;
            }

            public int TimeMinute()
            {
                return Minute;
            }

            public int TimeSecond()
            {
                return Second;
            }

            public string TimePassworld()
            {
                return Passworld;
            }

            public void Embed(string passworld, int hour = 0, int minute = 0, int second = 0)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
                var md5create = MD5.Create();
                var md5pass = md5create.ComputeHash(Encoding.UTF8.GetBytes(passworld));

                //string lol = Encoding.UTF8.GetString(md5pass);
                Passworld = Convert.ToBase64String(md5pass);
            }

            private void Tick()
            {
                if (Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower") == false)
                {
                    Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower");
                }

                //if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Time.txt") == false)
                //{
                //    File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Time.txt");
                //    File.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Time.txt");
                //}

                if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt") == false)
                {
                    File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt");
                    File.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt");
                }
                Task.Delay(100).Wait();

                //if (Settings.Default.ControlWinloc == true)
                File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt", Convert.ToString(Passworld));

                if (Settings.Default.ControlWinloc == true)
                {
                    //Process.Start("Winloc.exe");

                    //тут не понятный баг!

                    Process proc = new Process();
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.FileName = "Winloc.exe";
                    process.Verb = "runas";
                    proc.StartInfo = process;
                    proc.Start();
                }
                else
                {
                    Process.Start("ControlWin.exe");
                }
            }

            public void Start()
            {
                thread = new Thread(new ThreadStart(Work));
                thread.Start();
            }

            private void Work()
            {
                while (true)
                {
                    Thread.Sleep(1000);

                    Second--;

                    if (Second == 0)
                    {
                        if (Minute == 0)
                        {
                            if (Hour == 0)
                            {
                                if (Second == 0 && Minute == 0 && Hour == 0)
                                {
                                    Tick();
                                }
                            }
                            Minute = 59;
                            Hour--;
                        }
                        Second = 59;
                        Minute--;
                    }

                }
            }
        }
    }
}

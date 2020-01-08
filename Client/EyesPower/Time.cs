using System;
using EyesPower.Properties;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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
                Passworld = Encoding.UTF8.GetString(md5pass);
            }

            private void GetTime()
            {

            }

            private void Tick()
            {
                if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Time.txt"))
                {
                    File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Timme.txt");
                }

                if (File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt"))
                {
                    File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt");
                }

                File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Time.txt", "Yes");
                File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt", Passworld);
                if (Settings.Default.ControlWinloc == true)
                    Process.Start("Winloc.exe");
                else
                    Process.Start("ControlWin.exe");
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

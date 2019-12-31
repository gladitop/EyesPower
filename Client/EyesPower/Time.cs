using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EyesPower
{
    static class Time
    {
        public struct tamer
        {
            int Hour;
            int Minute;
            int Second;
            string Passworld;

            public void Embed(string passworld, int hour = 0, int minute = 0, int second = 0)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
                var md5create = MD5.Create();
                var md5pass = md5create.ComputeHash(Encoding.UTF8.GetBytes(passworld));
                Passworld = Encoding.UTF8.GetString(md5pass);
            }

            void Tick()
            {
                File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Yes.txt", "Yes");
                File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Passworld.txt", Passworld);
            }

            public void Start()
            {
                Thread thread = new Thread(new ThreadStart(Work));
                thread.Start();
            }

            void Work()
            {
                while (true)
                {
                    Second--;

                    if (Second == 0)
                    {
                        if (Minute == 0)
                        {
                            if (Hour == 0)
                            {
                                if (Second == 0 && Minute == 0 && Hour == 0)
                                    Tick();
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

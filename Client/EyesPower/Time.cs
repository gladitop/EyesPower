using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EyesPower
{
    static class Time
    {
        public struct tamer
        {
            int Hour;
            int Minute;
            int Second;

            public void Embed(int hour = 0, int minute = 0, int second = 0)
            {
                Hour = hour;
                Minute = minute;
                Second = second;
            }

            void Tick()
            {

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

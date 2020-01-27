using EyesPower.Properties;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EyesPower
{
    public static class ProgramTryClass
    {
        public static void Update()
        {
            if (Settings.Default.Program == true)
            {
                Data.GetProcess();
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Data.GetProcess();
                    Process[] processes = Process.GetProcesses();
                    bool yes = false;

                    foreach (Process process in processes)
                    {
                        foreach (string proc in Data.Process)
                        {
                            if (proc == process.ProcessName)
                            {
                                yes = true;
                            }
                        }

                        if (yes == true)
                        {
                            Environment.Exit(0);
                        }

                        yes = false;
                    }
                }
            }
            Thread.Sleep(0);
        }
    }
}

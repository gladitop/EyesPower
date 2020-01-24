using EyesPower.Properties;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EyesPower
{
    public static class ProgramTryClass
    {
        public static void Update()
        {
            if (Settings.Default.Program == true)
            {
                while (true)
                {
                    Task.Delay(100).Wait();
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
                            MessageBox.Show("1");
                        }

                        yes = false;
                    }
                }
            }
            Thread.Sleep(0);
        }
    }
}

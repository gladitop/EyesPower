using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace EyesPower
{
    public static class Data
    {
        public static Socket client;//для подключение к серверу

        //От быстрой настройки

        public static bool yesHelp = false;//помощь есть? (то есть отсылать данные мне :) )
        public static bool Program = false;//Используваете вы специальные программы (фотошоп и дургие)
        public static bool Training = false;//Тренировки
        public static bool Update = false;//Автомочитеская проверка обновлений

        //разные подтверждения

        public static bool UpdateCustomizationing = false;//Проверка настройки
        public static bool ExitMain = false;//Это нужно чтобы закрыть Main

        //Для регистрации

        public static string email = "";//email
        public static string passworld = "";//пароль

        //Разные данные

        public static string version = "1.0";//версия программы
        public static TimeSpan time;//Для контроля
        public static bool ExitLogin = false;//исправление бага
        public static object timer;//Это сам таймер
        public static bool ExitNewAccount = false;//После регистрации
        public static bool TraningGood = false;//Это говорит что тренировка завершина успешно
        public static bool ProcessYes = false;//Это говорит если есть процесс которое в Process

        //Программы исключение (данные)

        public static List<string> Process = new List<string>();//Если эти процессы есть то надо бежать...

        public static void GetProcess()//Получение
        {
            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt") == true)
            {
                string[] read = File.ReadAllLines($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt");

                foreach (string str in read)
                {
                    if (ProgramTryClass.Proverca(str))
                        Process.Add(str);
                }
            }
        }

        public static void SetProcess()//Сохранение
        {
            if (Directory.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower") == false)
            {
                Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower");
            }

            if (File.Exists($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt") == false)
            {
                //File.Delete($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt");
                //File.Create($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt");
            }

            using (StreamWriter rw = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}/EyesPower/Process.txt"))
            {
                rw.AutoFlush = true;

                foreach (string write in Process)
                {
                    rw.WriteLine(write);
                }

                rw.Close();
            }
        }
    }
}

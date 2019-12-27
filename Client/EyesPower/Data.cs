using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EyesPower.Properties;

namespace EyesPower
{
    static public class Data
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

        //Настройки

        public static void UpdateSettings()//Для обновление настройки
        {
            
        }
    }
}

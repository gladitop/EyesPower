using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyesPower.Pages
{
    static class Data//Это для хранение переменных (только для быстрой настройки)
    {
        //для быстрой настройки

        public static bool yesHelp = false;//помощь есть? (то есть отсылать данные мне :) )
        public static short numberanswer = 1;// счёт
        public static bool exit = false;//Закрыть форму настройки
        public static bool NewPage = false;//Для нормального обновление страниц (след. страница)
        public static bool BackPage = false;//Для нормального обновление страниц (назад страница)
        public static bool Program = false;//Используваете вы специальные программы (фотошоп и дургие)
        public static bool Training = false;//Тренировки (сообщать)
        public static bool Update = false;//Автомочитеская проверка обновлений

        //Для тренировки

        public static bool YesTraining = false;//Есть подтверждение тренировки
    }
}

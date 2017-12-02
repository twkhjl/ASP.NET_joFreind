using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.helper
{
    public class TimeHelper
    {
        public static String getWeekDaysTW_NOW()
        {
            String result = "";

            String[] weeksArr =
            {
                "星期日",
                "星期一",
                "星期二",
                "星期三",
                "星期四",
                "星期五",
                "星期六",
            };
            int i = int.Parse(DateTime.Now.DayOfWeek.ToString("d"));//tmp2 = 4 

            result = weeksArr[i];
            return result;
        }
        public static String getWeekDaysTW(DateTime dateTime)
        {
            String result = "";

            String[] weeksArr =
            {
                "星期日",
                "星期一",
                "星期二",
                "星期三",
                "星期四",
                "星期五",
                "星期六",
            };
            int i = int.Parse(dateTime.DayOfWeek.ToString("d"));//tmp2 = 4 

            result = weeksArr[i];
            return result;
        }
        public static String custom(String timeFormat, DateTime dateTime)
        {
            String result = "";
            result = string.Format("{0:" + timeFormat + "}", dateTime);

            return result;

        }

        public static String custom_Now(String timeFormat)
        {
            String result = "";
            result = string.Format("{0:" + timeFormat + "}", DateTime.Now);

            return result;

        }

        public static String YMDW_Now()
        {
            String result = "";

            result = string.Format("{0:yyyy/MM/dd }{1} ", DateTime.Now, getWeekDaysTW_NOW());

            return result;
        }
        public static String YMDW(DateTime dateTime)
        {
            String result = "";
            result = string.Format("{0:yyyy/MM/dd }{1} ", dateTime, getWeekDaysTW_NOW());

            return result;

        }
        public static String YMD(DateTime dateTime)
        {
            String result = "";
            result = string.Format("{0:yyyy/MM/dd }", dateTime);

            return result;

        }
    }
}
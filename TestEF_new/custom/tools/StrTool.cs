using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace custom.tools
{
    public class StrTool
    {
        //檢查字串是否為空白,tab或null
        public static bool chkIsWhiteSpace(String text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            return false;
        }

        //檢查文字是否為正整數
        public static bool chkPositiveInt32(String text)
        {
            int v = 0;

            if (text.Length <= 0)
            {
                return false;
            }
            if (!System.Int32.TryParse(text, out v))
            {
                return false;
            }
            if (v <= 0)
            {
                return false;
            }
            return true;
        }

        //檢查字串是否符合正則表達式規則
        public static bool chkRegEx(String text, String expr)
        {
            int strLength = 0;

            String result = Regex.Match(text, expr).ToString();
            strLength = result.Length;

            if (strLength == 0)
            {
                return false;
            }
            return true;
        }

        //檢查字串是否僅含有英數及底線
        public static bool validAccountFormat(string account)
        {
            return !chkRegEx(account,@"^[a-zA-Z0-9_]+$");
           
        }


        //檢查字串是否為正確email格式
        public static bool isValidEmail(String email)
        {
            return chkRegEx(email,"^[a-z0-9-]+([.]" +
                    "[_a-z0-9-]+)*@[a-z0-9-]+([.][a-z0-9-]+)*$");
        }

        //檢查字串是否為正確臺灣手機號碼格式
        public static bool isValidMobileTW(string account)
        {
            return !chkRegEx(account, @"[0-9]{4}-[0-9]{3}-[0-9]{3}");

        }


      
    }
}
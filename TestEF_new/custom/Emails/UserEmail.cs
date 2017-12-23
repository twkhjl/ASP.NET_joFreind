using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TestEF_new.Models;
using custom.tools;

namespace Models.email
{
    public class UsersEmail
    {
        public static Dictionary<string, string> mailTitle = new Dictionary<string, string>()
        {
            {"validateTitle","您好,請驗證您的jofriend帳號"},
            {"resetPasswordTitle","您好,請重設您的jofriend帳號密碼"}
        };


        public static void sendValidateEmail(users user,string baseUrl)
        {
            MailTool.sendEmail(user.email, mailTitle["validateTitle"], validateContent(user, baseUrl));
        }

        public static void sendResetPasswordEmail(users user, string baseUrl)
        {
            MailTool.sendEmail(user.email, mailTitle["resetPasswordTitle"], resetPasswordContent(user, baseUrl));
        }


        private static String validateContent(users user, string baseUrl)
        {
            String url = "";

            url = String.Format("{0}/activate/users/{1}/{2}",baseUrl, HashTool.GetMd5Hash(user.userID.ToString()), user.userID);


            String content =String.Format(
@"
請點擊下方連結以驗證您的joFriend帳號:
{0}
",url);

            return content;
        }

        private static String resetPasswordContent(users user, string baseUrl)
        {
            String url = "";

            url = String.Format("{0}/reset/users/{1}/{2}", baseUrl, HashTool.GetMd5Hash(user.userID.ToString()), user.userID);


            String content = String.Format(
@"
請點擊下方連結以重設您的joFriend帳號密碼:
{0}
", url);

            return content;
        }
    }
}
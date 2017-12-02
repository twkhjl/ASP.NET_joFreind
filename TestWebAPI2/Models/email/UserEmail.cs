using Models.blueprint.tableClass;
using Models.helper;
using Models.sqlCmd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Models.email
{
    public class UserEmail
    {
        public static Dictionary<string, string> mailTitle = new Dictionary<string, string>()
        {
            { "validateTitle","請驗證您的帳號" }
        };


        public static void sendValidateEmail(Users user,string baseUrl)
        {
            MailHelper.sendEmail(user.email, mailTitle["validateTitle"], validateContent(user, baseUrl));
        }

        private static String validateContent(Users user, string baseUrl)
        {
            String url = "";

            url = String.Format("{0}/activate/user/{1}/{2}",baseUrl, HashHelper.getHash(user.userID.ToString()), user.userID);

            DataTable dt = UsersCmd.selectOne<String>("email", user.email);


            String content =String.Format(
@"

點擊下方連結以驗證您的帳號:
{0}

",url);

            return content;
        }
    }
}
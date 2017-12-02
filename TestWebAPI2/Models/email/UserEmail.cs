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


        public static void sendValidateEmail(string mailTo)
        {
            MailHelper.sendEmail(mailTo, mailTitle["validateTitle"], validateContent(mailTo));
        }

        private static String validateContent(string mailTo)
        {
            String url = "";

            DataTable dt = UsersCmd.selectOne<String>("email",mailTo);

            Users user = new Users();
            user.userID = (int)dt.Rows[0]["userID"];
            user.email = dt.Rows[0]["email"].ToString();
            user.status = 
                Convert.IsDBNull(dt.Rows[0]["status"])?0:(int)dt.Rows[0]["status"];





            String content =String.Format(
@"
<!DOCTYPE html>
< head >
< meta charset = 'UTF-8' >
< meta name = 'viewport' content = 'width=device-width, initial-scale=1.0' >
< meta http - equiv = 'X-UA-Compatible' content = 'ie=edge' >
< link rel = 'stylesheet' href = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css' >
< link href = '//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css' rel = 'stylesheet' >

</ head >
< body >
< div class='container'>
<div class='row'>
<div class='col-sm-8 col-sm-offset-2'>
點擊下方連結以驗證您的帳號:
<a href='{0}'>驗證連結</a>
</div>
</div>
</div>




<!-- script CDN -->
<script src = 'https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js' ></ script >
< script src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>

</ body >
</ html >


",url);

            return content;
        }
    }
}
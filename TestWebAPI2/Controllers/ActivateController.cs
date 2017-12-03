using Models.helper;
using Models.sqlCmd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace TestWebAPI2.Controllers
{
    [RoutePrefix("activate")]
    public class ActivateController : ApiController
    {

        [HttpGet]
        [Route("user/{hashed}/{userID}")]
        public HttpResponseMessage Get(string userID, string hashed)
        {
            if (!HashHelper.VerifyMd5Hash(userID,hashed))
            {
                var err = new { err = "verify url format invalid" };
                return JsonHelper.toJson(err);
            }

            DataTable dt = UsersCmd.selectOne<String>("userID", userID);

            int status = (int)dt.Rows[0]["status"];

            String baseURL = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            String url = baseURL+"/front/showMsg.html";
            String msgToken = "";
            String userEmail = "";
            String htmlStr = "";

            if (status.Equals(-1))
            {
                msgToken= "userBanned";
            }
            if (status.Equals(0))
            {
                UsersCmd.activate(userID);
                DataTable dtTmp = UsersCmd.selectOne<String>("userID", userID);
                userEmail = dtTmp.Rows[0]["email"].ToString();
                msgToken = "userActivated";
            }
            if (status.Equals(1))
            {
                msgToken = "userAlreadyActivated";
            }

            htmlStr =
@"
<!DOCTYPE html>
<html lang='en'>
<head>
<title>plz w8</title>
<meta charset = 'utf-8'>
<meta name = 'viewport' content = 'width=device-width, initial-scale=1'>
<link rel = 'stylesheet' href = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>
<script src = 'https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>
<script src = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js'></script>
</head>
<body>
<div class='container'>
</div>
<script>
"
+ "sessionStorage.setItem('msgToken'," + "'"+msgToken+"'" + ");"
+ "sessionStorage.setItem('userName'," + "'" + msgToken + "'" + ");"
+ "sessionStorage.setItem('userEmail'," + "'" + userEmail + "'" + ");"
+ "window.location='" + url+"';"

 + @"
</script>
</body>
</html>";

var response = new HttpResponseMessage();
response.Content = new StringContent(htmlStr);
response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
return response;

        }

    }
}

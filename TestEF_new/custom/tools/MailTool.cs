using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TestEF.custom.config;

namespace custom.tools
{
    public class MailTool
    {
        //https://stackoverflow.com/questions/704636/sending-email-through-gmail-smtp-server-with-c-sharp
        public static void sendEmail(string receiver,string title,string content)
        {
            var client = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential(EmailConfig.EMAIL, EmailConfig.PASSWORD),
                EnableSsl = true
            };

            client.Send(EmailConfig.EMAIL, receiver, title, content);
        }



        //https://stackoverflow.com/questions/25860975/send-email-through-asp-net-web-api
        //public static void sendEmail()
        //{
        //    string subject = "Email Subject";
        //    string body = "Email body";
        //    string FromMail = "iiiteamno3@gmail.com";
        //    string emailTo = "twkhjl@gmail.com";
        //    MailMessage mail = new MailMessage();
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    mail.From = new MailAddress(FromMail);
        //    mail.To.Add(emailTo);
        //    mail.Subject = subject;
        //    mail.Body = body;
        //    SmtpServer.Port = 25;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential("uraccount@gmail.com", "urpassword");
        //    SmtpServer.EnableSsl = true;
        //    SmtpServer.Send(mail);
        //}
    }
}
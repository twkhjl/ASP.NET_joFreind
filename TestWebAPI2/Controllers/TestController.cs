using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models.helper;

namespace TestWebAPI2.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        // GET: api/Test
        //public IEnumerable<string> Get()
        //{
        //    //MailHelper.sendEmail();
        //    //MailHelper.sendEmail("twkhjl@gmail.com","this is title","this is content");

        //    return new string[] { "value1", "value2" };
        //}

        [Route("")]
        public string Get()
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            return baseUrl;
        }
        // GET: api/Test/5
        [Route("test1/{userID}")]
        public string Get(string userID)
        {
            string encrypted = HashHelper.Encrypt(userID, "123");
            string decrypted= HashHelper.Decrypt(encrypted, "123");

            return String .Format(@"
encrypted text:{0},
decrypted  text:{1}",
encrypted,decrypted);
        }

        // POST: api/Test
        public String Post([FromBody]string value)
        {
            return value;
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}

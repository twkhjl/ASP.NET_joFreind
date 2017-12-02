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

        [Route("")]
        public string Get()
        {
            var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            return baseUrl;
        }
        // GET: test/test1/aaa
        [Route("test1/{str}")]
        public string Get(string str)
        {
            string hash = HashHelper.GetMd5Hash(str);

            Console.WriteLine("The MD5 hash of " + str + " is: " + hash + ".");

            bool isMatch = HashHelper.VerifyMd5Hash(str, hash);
            

            return String .Format("hash:{0},original text:{1},is match:{2}",
hash,str, isMatch);
        }

        //// POST: api/Test
        //public String Post([FromBody]string value)
        //{
        //    return value;
        //}

        //// PUT: api/Test/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Test/5
        //public void Delete(int id)
        //{
        //}
    }
}

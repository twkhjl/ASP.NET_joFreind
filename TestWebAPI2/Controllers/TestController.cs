using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models.helper;
using System.IO;
using System.Net.Http.Headers;

namespace TestWebAPI2.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {

        // GET: test/test1/

        [Route("test1")]
        public IHttpActionResult Get()
        {
            String baseURL = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            return Redirect(baseURL+"/front/index.html");

        }

        [Route("test2")]
        [HttpGet]
        public HttpResponseMessage testHtmlStr()
        {
            String baseURL = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            String url = baseURL + "/front/index.html";
            String htmlStr =
                String.Format(
            @"<script>window.location='{0}';</script>", url);

            var response = new HttpResponseMessage();
            response.Content = new StringContent(htmlStr);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

    }
}

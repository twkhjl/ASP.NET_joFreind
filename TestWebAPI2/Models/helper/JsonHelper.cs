using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace Models.helper
{
    public class JsonHelper
    {
        public static HttpResponseMessage toJson(Object obj)
        {
            var serializedResult = JsonConvert.SerializeObject(obj);
            return sendResponse(serializedResult);
        }
        public static dynamic fromJson(String jsonStr)
        {
            dynamic stuff = JsonConvert.DeserializeObject(jsonStr);
            return stuff;

            //example usage:
            //String jsonStr = "[{\"value\":\"test\"},{\"value\":\"test2\"}]";
            //var obj = JsonHelper.fromJson(jsonStr);
            //String value = obj[1].value;
        }



        public static HttpResponseMessage sendResponse(String str)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(str, System.Text.Encoding.UTF8, "text/html");
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;

        }

     


    }
}
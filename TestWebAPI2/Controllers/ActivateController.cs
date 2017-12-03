using Models.helper;
using Models.sqlCmd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            if (status.Equals(-1))
            {
                var err = new { err = "account banned" };
                return JsonHelper.toJson(err);
            }
            if (status.Equals(0))
            {
                UsersCmd.activate(userID);
            }
            if (status.Equals(1))
            {
                var err = new { err = "account already activated" };
                return JsonHelper.toJson(err);
            }

            var result = new { result = "ok" };
            return JsonHelper.toJson(result);

        }

    }
}

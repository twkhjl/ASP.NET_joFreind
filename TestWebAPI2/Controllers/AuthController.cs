using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Models.factory;
using Models.blueprint.tableClass;
using Models.helper;
using Models.validate;
using Models.blueprint.formClass;
using Models.blueprint.errClass;
using Models.auth;

namespace TestWebAPI2.Controllers
{
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("api/adminLogin")]
        public HttpResponseMessage Login([FromBody]Admin data)
        {
            Admin obj = AdminAuth.chkAccount(data);

            if (obj == null)
            {
                var err = new { err = "loginErr" };
                return JsonHelper.toJson(err);
            }

            return JsonHelper.toJson(obj);
        }

        [HttpPost]
        [Route("api/userLogin")]
        public HttpResponseMessage userLogin([FromBody]FormUserLogin data)
        {
            object obj = UserAuth.chkAccount(data);
            return JsonHelper.toJson(obj);

            //Users obj = UserAuth.chkAccount(data);

            //if (obj == null)
            //{
            //    var err = new { loginErr = 1};
            //    return JsonHelper.toJson(err);
            //}

            //return JsonHelper.toJson(obj);
        }
    }
}

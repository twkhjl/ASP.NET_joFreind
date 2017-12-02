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
using Models.blueprint.jsonClass;
using Models.helper;

namespace TestWebAPI2.Controllers
{
    public class ActivateURLController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }






    }
}

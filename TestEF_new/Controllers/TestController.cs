using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestEF_new.Models;

using custom.tools;
using custom.formClass.users;
using System.Web.Http.ModelBinding;
using System.Globalization;
using Models.email;
using custom.ADONET;

namespace TestEF_new.Controllers
{
    public class TestController : ApiController
    {
        private JofriendEntities db = new JofriendEntities();

        [HttpGet]
        [Route("test/t1")]
        public dynamic GetUsers()
        {
            return HashTool.verify("12345", "$2a$10$ayRGdkzRo/i3/DuE8AIqhOpNtRZaYnxdCVpRd3AkZrr.Pg4jkOLde");
        }
    }
}

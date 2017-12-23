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
    public class CategoryController : ApiController
    {
        private JofriendEntities db = new JofriendEntities();

        [HttpGet]
        [Route("api/categories")]
        public dynamic GetCategories()
        {
            return db.Category
              .Select(x=>x).ToArray();
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public dynamic getCategoryByID(int id)
        {
            return
            (
                from p in db.Category
                where p.CategoryID == id
                select p
            ).ToArray();
        }
    }
}

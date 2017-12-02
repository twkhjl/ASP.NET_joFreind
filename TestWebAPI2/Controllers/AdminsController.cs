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

namespace TestWebAPI2.Controllers
{
    public class AdminsController : ApiController
    {
        AdminFactory factory = new AdminFactory();

//------------------GET--------------

        [HttpGet]
        public HttpResponseMessage FindOne(int id)
        {
            factory.moveTo(id);
            var obj = factory.getCurrent();

            if (obj == null)
            {
                var err = new { err = "recordNotFound" };
                return JsonHelper.toJson(err);
            }
            return JsonHelper.toJson(obj);
        }
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var obj = factory.getAll();
         

            return JsonHelper.toJson(obj);
        }

 //-----------------POST------------------------ 

        [HttpPost]
        public HttpResponseMessage AddOne([FromBody]AdminForm data)
        {
            AdminErrClass err = AdminValidate.chkFormAdd(data);
            if (err != null)
            {
                return JsonHelper.toJson(err);
            }

            Admin obj = new Admin();
            obj.account = data.account;
            obj.password = data.password;

            factory.addOne(obj);
            factory.getAll();
            factory.moveToLast();
            var newOne = factory.getCurrent();
            return JsonHelper.toJson(newOne);
        }

        [HttpPost]
        [Route("api/admins/del")]
        public HttpResponseMessage DelOne([FromBody]Admin data)
        {
            factory.delOne(data);
            AdminJson deletedOne = new AdminJson();
            deletedOne.adminID = data.adminID;
            deletedOne.account = data.account;

            return JsonHelper.toJson(deletedOne);
        }




    }
}

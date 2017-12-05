﻿using System;
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
using Models.email;

namespace TestWebAPI2.Controllers
{
    public class UsersController : ApiController
    {
        UsersFactory factory = new UsersFactory();

        //------------------GET--------------

        [HttpGet]
        [Route("api/users/{id}")]
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
        [Route("api/users")]
        public HttpResponseMessage GetAll()
        {
            var obj = factory.getAll();


            return JsonHelper.toJson(obj);
        }

        //-----------------POST------------------------ 

        [HttpPost]
        [Route("api/users/register")]
        public HttpResponseMessage AddOne([FromBody]FormUserRegister data)
        {
            UserErrClass err = UserValidate.chkUserRegister(data);
            if (err != null)
            {
                return JsonHelper.toJson(err);
            }

            //insert new record
            Users obj = new Users();
            obj.email = data.email;
            obj.password = data.password;
            

            factory.addOne(obj);
            factory.getAll();
            factory.moveToLast();
            var newOne = factory.getCurrent();

            obj.userID = factory.getCurrent().userID;

            //send verify email
            string baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            UserEmail.sendValidateEmail(obj, baseUrl);
            

            return JsonHelper.toJson(newOne);
        }

        

        //[HttpPost]
        //[Route("api/admins/del")]
        //public HttpResponseMessage DelOne([FromBody]Admin data)
        //{
        //    factory.delOne(data);
        //    AdminJson deletedOne = new AdminJson();
        //    deletedOne.adminID = data.adminID;
        //    deletedOne.account = data.account;

        //    return JsonHelper.toJson(deletedOne);
        //}




    }
}

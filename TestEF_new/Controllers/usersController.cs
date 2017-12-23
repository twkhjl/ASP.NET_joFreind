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
    public class usersController : ApiController
    {
        private JofriendEntities db = new JofriendEntities();

        [HttpGet]
        [Route("api/users")]
        public dynamic GetUsers()
        {
            return db.users
              .Select(x => new
              {
                  x.userID,
                  x.email,
                  x.gender,
                  x.createAt,
                  x.updateAt
              }).ToArray();
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public dynamic getUserByID(int id)
        {
            return
            (
                from p in db.users
                where p.userID == id
                select new
                {
                    p.userID,
                    p.email,
                    p.name,
                    p.gender,
                    p.birthDate,
                    p.createAt,
                    p.updateAt
                }
            ).ToArray();
        }

        [HttpPost]
        [Route("api/users/register")]
        public dynamic userRegister(FormUsersRegister data)
        {
            List<string> errList = new List<string>();
            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errList.Add(error.ErrorMessage.ToString());
                }
            }

            if (db.users.Any(o => o.email == data.email))
            {
                errList.Add("emailExistErr");
            }

            if (db.users.Any(o => o.nickname == data.nickname))
            {
                errList.Add("nicknameExistErr");
            }

            if (errList.Count > 0)
            {
                return JsonTool.toJson(errList);
            }

            users newOne = new users
            {
                email = data.email,
                nickname = data.nickname,
                password = HashTool.getHash(data.password),
                gender = data.gender,
                birthDate = DateTime.ParseExact(data.birthDate.Replace("-", "/"), "yyyy/MM/dd", CultureInfo.InvariantCulture),
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            };

            if (UsersCmd.insert(newOne) <= 0)
            {
                errList.Add("dbInsertErr");
                return JsonTool.toJson(errList);
            };

            newOne.userID = (from p in db.users
                             where p.email == data.email
                             select p).SingleOrDefault().userID;


            //send verify email
            string baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

            UsersEmail.sendValidateEmail(newOne, baseUrl);

            var obj =
            (
                from p in db.users
                where p.userID == newOne.userID
                select new
                {
                    p.userID,
                    p.email,
                    p.nickname,
                    p.gender,
                    p.birthDate,
                    p.createAt
                }
            ).SingleOrDefault();
            return JsonTool.toJson(obj);
        }

        [HttpPost]
        [Route("api/users/login")]
        //public dynamic Postusers(dynamic data)
        public dynamic userLogin(FormUsersLogin data)
        {
            //return ModelState.ToArray();
            List<string> errList = new List<string>();

            if (!db.users.Any(o => o.email == data.email))
            {
                errList.Add("emailNotExistErr");
                return JsonTool.toJson(errList);
            }

            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errList.Add(error.ErrorMessage.ToString());
                }
            }
            if (errList.Count > 0)
            {
                return JsonTool.toJson(errList);
            }

            var user = (from p in db.users
                        where p.email == data.email
                        select p).SingleOrDefault();
            int status = (int)user.status;

            if (status == -1)
            {
                errList.Add("userBannedErr");
                return JsonTool.toJson(errList);
            }
            if (status == 0)
            {
                errList.Add("userNotActivateErr");
                return JsonTool.toJson(errList);
            }


            string hash = user.password;

            if (!HashTool.verify(data.password, hash))
            {
                errList.Add("passwordInCorrectErr");
                return JsonTool.toJson(errList);
            }

            var obj =
            (
                from p in db.users
                where p.email == data.email
                select new
                {
                    p.userID,
                    p.email,
                    p.nickname,
                    p.gender,
                    p.birthDate,
                    p.createAt,
                    p.updateAt
                }
            ).SingleOrDefault();
            return JsonTool.toJson(obj);
        }

        [HttpPost]
        [Route("api/users/forgotPassword/email")]
        //public dynamic Postusers(dynamic data)
        public dynamic forgotPassword_email(users data)
        {
            List<string> errList = new List<string>();
            if (!db.users.Any(o => o.email == data.email))
            {
                errList.Add("emailNotExistErr");
                return JsonTool.toJson(errList);
            }

            var user = (from p in db.users
                        where p.email == data.email
                        select p).SingleOrDefault();
            int status = (int)user.status;

            if (status == -1)
            {
                errList.Add("userBannedErr");
                return JsonTool.toJson(errList);
            }
            if (status == 0)
            {
                errList.Add("userNotActivateErr");
                return JsonTool.toJson(errList);
            }

            //send reset password email
            string baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
            UsersEmail.sendResetPasswordEmail(user, baseUrl);

            return JsonTool.toJson(user);
        }
        [HttpPost]
        [Route("api/users/reset/password")]
        //public dynamic Postusers(dynamic data)
        public dynamic resetPassword(FormUsersResetPassword data)
        {
            
            List<string> errList = new List<string>();
            if (!db.users.Any(o => o.userID == data.userID))
            {
                errList.Add("userNotExistErr");
                return JsonTool.toJson(errList);
            }

            var user = (from p in db.users
                        where p.userID == data.userID
                        select p).SingleOrDefault();
            int status = (int)user.status;

            if (status == -1)
            {
                errList.Add("userBannedErr");
                return JsonTool.toJson(errList);
            }
            if (status == 0)
            {
                errList.Add("userNotActivateErr");
                return JsonTool.toJson(errList);
            }

            foreach (ModelState modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errList.Add(error.ErrorMessage.ToString());
                }
            }

            if (errList.Count > 0)
            {
                return JsonTool.toJson(errList);
            }

            user.password = HashTool.getHash(data.password);
            UsersCmd.changePassword(user);
            return JsonTool.toJson(user);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usersExists(int id)
        {
            return db.users.Count(e => e.userID == id) > 0;
        }
    }
}
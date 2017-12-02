﻿using Models.helper;
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
        public string Get(string userID, string hashed)
        {
            if (!HashHelper.verify(userID,hashed))
            {
                return "not ok";
            }

            //DataTable dt = UsersCmd.selectOne<String>("userID", userID);

            //int status = (int)dt.Rows[0]["status"];

            //if (status.Equals(-1))
            //{
            //    return "err:account banned";
            //}
            //if (status.Equals(0))
            //{
            //    UsersCmd.activate(userID);
            //}
            //if (status.Equals(1))
            //{
            //    return "err:account already activated";
            //}

            return "ok";


            //return
            //    String.Format("userID:{0},encrypted userID:{1},decrypted userID:{2}",
            //    userID, encrypted, HashHelper.Decrypt(encrypted, passwd)
            //    );
        }

    }
}
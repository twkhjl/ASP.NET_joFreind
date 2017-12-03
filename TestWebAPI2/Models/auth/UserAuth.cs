using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Models.helper;
using Models.blueprint.tableClass;
using Models.blueprint.formClass;
using System.Data;
using Models.sqlCmd;

namespace Models.auth
{
    public class UserAuth
    {
        public static dynamic chkAccount(FormUserLogin data)
        {
            DataTable dt = new DataTable();
           
            dt = UsersCmd.selectOne<String>("email", data.email);

            if (dt.Rows.Count <= 0)
            {
                return null;
            }

            if ((int)dt.Rows[0]["status"] == -1)
            {
                return new {err="userBannedErr" };
            }

            if ((int)dt.Rows[0]["status"] == 0)
            {
                return new { err = "userNotActivateErr" };
            }

            if (!HashHelper.verify(data.password, dt.Rows[0]["password"].ToString()))
            {
                return null;
            }

            Users result = new Users();

            result.userID = (int)dt.Rows[0]["userID"];
            result.email =
                Convert.IsDBNull(dt.Rows[0]["email"].ToString())?"": dt.Rows[0]["email"].ToString();
            
            result.status = (int)dt.Rows[0]["status"];
            result.authority = (int)dt.Rows[0]["authority"];
            result.status = (int)dt.Rows[0]["status"];
            result.createAt = (DateTime)dt.Rows[0]["createAt"];
            result.updateAt = (DateTime)dt.Rows[0]["updateAt"];

            return result;


        }
    }
}
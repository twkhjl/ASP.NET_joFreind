using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Models.helper;
using Models.blueprint.tableClass;
using System.Data;
using Models.sqlCmd;

namespace Models.auth
{
    public class AdminAuth
    {
        public static Admin chkAccount(Admin data)
        {
            DataTable dt = new DataTable();
           
            dt = AdminCmd.selectOne<String>("account",data.account);

            if (dt.Rows.Count <= 0)
            {
                return null;
            }

            if (!HashHelper.verify(data.password, dt.Rows[0]["password"].ToString()))
            {
                return null;
            }

            Admin result = new Admin();

            result.adminID = (int)dt.Rows[0]["adminID"];
            result.account = dt.Rows[0]["account"].ToString();
            result.status = (int)dt.Rows[0]["status"];
            result.authority = (int)dt.Rows[0]["authority"];
            result.status = (int)dt.Rows[0]["status"];
            result.createAt = (DateTime)dt.Rows[0]["createAt"];
            result.updateAt = (DateTime)dt.Rows[0]["updateAt"];

            return result;


        }
    }
}
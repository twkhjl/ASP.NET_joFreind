using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Models.factory;
using Models.blueprint.tableClass;
using Models.helper;
using Models.blueprint.formClass;
using Models.blueprint.errClass;
using Models.sqlCmd;
using System.Data;

namespace Models.validate
{
    public class AdminValidate
    {
        public static AdminErrClass chkFormAdd(AdminForm data)
        {
            int cnt = 0;
            AdminErrClass err = new AdminErrClass();

            if (StrHelper.chkIsWhiteSpace(data.account))
            {
                err.accountBlankErr = 1;
                cnt++;
            }
            else if (StrHelper.validAccountFormat(data.account))
            {
                err.accountFormatErr = 1;
                cnt++;
            }
            else
            {
                DataTable dt = AdminCmd.selectOne<String>("account",data.account);
                if (dt.Rows.Count > 0)
                {
                    err.accountExistErr = 1;
                    cnt++;
                }

            }

            if (StrHelper.chkIsWhiteSpace(data.password))
            {
                err.passwordBlankErr = 1;
                cnt++;
            }

            if (!data.password.Equals(data.confirmPwd))
            {
                err.passwordNotMatchErr = 1;
                cnt++;
            }

            if (cnt == 0)
            {
                return null;
            }
            return err;
        }
    }
}
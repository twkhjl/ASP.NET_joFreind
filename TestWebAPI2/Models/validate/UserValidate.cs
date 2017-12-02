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
    public class UserValidate
    {
        public static UserErrClass chkUserRegister(FormUserRegister data)
        {
            int cnt = 0;
            UserErrClass err = new UserErrClass();

            if (StrHelper.chkIsWhiteSpace(data.email))
            {
                err.emailBlankErr = 1;
                cnt++;
            }
            else if (StrHelper.isValidEmail(data.email))
            {
                err.emailFormatErr = 1;
                cnt++;
            }
            else
            {
                DataTable dt = UsersCmd.selectOne<String>("email",data.email);
                if (dt.Rows.Count > 0)
                {
                    err.emailExistErr = 1;
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
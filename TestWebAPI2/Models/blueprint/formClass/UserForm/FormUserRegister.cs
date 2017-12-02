using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.blueprint.formClass
{
    public class FormUserRegister
    {
        private String _email;
        private String _password;
        private String _confirmPwd;

        public string email {
            get { return _email; }
            set { _email = (value == null ? "" : value); } }

        public string confirmPwd
        {
            get { return _confirmPwd; }
            set { _confirmPwd = (value == null ? "" : value); }
        }
        public string password
        {
            get { return _password; }
            set { _password = (value == null ? "" : value); }
        }
    }
}
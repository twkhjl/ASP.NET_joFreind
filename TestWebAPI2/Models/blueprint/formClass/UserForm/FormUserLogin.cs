using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.blueprint.formClass
{
    public class FormUserLogin
    {
        private String _email;
        private String _password;
        private String _rememberMe;

        public string email {
            get { return _email; }
            set { _email = (value == null ? "" : value); } }

        public string password
        {
            get { return _password; }
            set { _password = (value == null ? "" : value); }
        }
        public string rememberMe
        {
            get { return _rememberMe; }
            set { _rememberMe = (value == null ? "" : value); }
        }
    }
}
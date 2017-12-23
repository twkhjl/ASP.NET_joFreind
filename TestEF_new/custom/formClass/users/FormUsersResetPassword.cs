using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace custom.formClass.users
{
    public class FormUsersResetPassword
    {
        public int userID { get; set; }

        [Required(ErrorMessage = "passwordBlankErr")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "passwordNotMatchErr")]
        public string confirmPwd { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace custom.formClass.users
{
    public class FormUsersLogin
    {
        [Required(ErrorMessage = "emailBlankErr")]
        public string email { get; set; }

        [Required(ErrorMessage = "passwordBlankErr")]
        public string password { get; set; }
    }
}
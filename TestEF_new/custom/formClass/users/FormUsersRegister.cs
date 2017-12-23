using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace custom.formClass.users
{
    public class FormUsersRegister
    {
        [Required(ErrorMessage = "emailBlankErr")]
        [EmailAddress(ErrorMessage = "emailFormatErr")]
        public string email { get; set; }

        [Required(ErrorMessage = "passwordBlankErr")]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "passwordNotMatchErr")]
        public string confirmPwd { get; set; }


        [Required(ErrorMessage = "nicknameBlankErr")]
        public string nickname { get; set; }

        [Required(ErrorMessage = "genderBlankErr")]
        public Nullable<int> gender { get; set; }

        [Required(ErrorMessage = "birthDateBlankErr")]
        
        public string birthDate { get; set; }
    }
}
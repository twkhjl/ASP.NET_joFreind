using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models.blueprint.tableClass
{
    public class Users
    {
        public Users() { }


        public int userID { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }
        
        public int status { get; set; }
        public int registerMode { get; set; }
        public int authority { get; set; }
        public string rememberToken { get; set; }

        public string name { get; set; }
        public string nickname { get; set; }
        public string intro { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public int gender { get; set; }
        public string imgUrl { get; set; }

        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }


    }
}
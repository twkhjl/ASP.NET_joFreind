using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models.blueprint.jsonClass
{
    public class UsersJson
    {
        public int userID { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public int status { get; set; }
        public int authority { get; set; }
        public int registerMode { get; set; }

        public string createAt { get; set; }
        public string updateAt { get; set; }
    }
}
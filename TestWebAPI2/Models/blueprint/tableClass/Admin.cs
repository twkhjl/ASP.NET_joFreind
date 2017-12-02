using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models.blueprint.tableClass
{
    public class Admin
    {
        public Admin() { }

        public Admin(int _id,string _account, string _password)
        {
            adminID = _id;
            account = _account;
            password = _password;
        }

        public Admin(string _account, string _password)
        {
            account = _account;
            password = _password;
        }

        public int adminID { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public int authority { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
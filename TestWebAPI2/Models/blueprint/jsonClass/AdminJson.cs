using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models.blueprint.jsonClass
{
    public class AdminJson
    {
        public int adminID { get; set; }
        public string account { get; set; }
        public int status { get; set; }
        public int authority { get; set; }
        public string createAt { get; set; }
        public string updateAt { get; set; }
    }
}
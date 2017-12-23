using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestEF.custom.config
{
    public class EmailConfig
    {
        private static String _email = "iiiteamno3@gmail.com";
        private static String _password = "P@ssword-123";

        public static String EMAIL { get { return _email; } }
        public static String PASSWORD { get { return _password; } }
    }
}
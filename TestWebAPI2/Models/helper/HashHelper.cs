using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.helper
{
    public class HashHelper
    {
        public static String getHash(string str)
        {
            return BCrypt.Net.BCrypt.HashPassword(str);
        }

        public static Boolean verify(string str,string hash)
        {
            return BCrypt.Net.BCrypt.Verify(str, hash);
        }
    }
}
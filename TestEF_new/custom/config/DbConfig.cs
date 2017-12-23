using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace custom.config
{
    public class DbConfig
    {
        private static String _dataSource = "jofriend-test.database.windows.net";
        private static String _userID = "iiiteamno3";
        private static String _password = "P@ssword-123";
        private static String _initialCatalog = "Jofriend";

        public static String DATA_SOURCE{ get{ return _dataSource;} }
        public static String USER_ID{ get{ return _userID; } }
        public static String PASSWORD{ get{ return _password; } }
        public static String INITIAL_CATALOG { get{ return _initialCatalog; } }
    }
}
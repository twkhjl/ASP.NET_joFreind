using custom.config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace custom.ADONET
{

    public class Db
    {

        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        String dataSource = DbConfig.DATA_SOURCE;
        String dbName = DbConfig.INITIAL_CATALOG;
        String userID= DbConfig.USER_ID;
        String password = DbConfig.PASSWORD;

        private static SqlConnection sqlCon { get; set; }

        private static Db instance;

        public static SqlConnection conn()
        {
            if (instance == null)
            {
                instance = new Db();
            }
            return sqlCon;
        }

        private Db()
        {
            scsb.DataSource = dataSource;
            scsb.InitialCatalog = dbName;
            scsb.UserID = userID;
            scsb.Password = password;
            sqlCon = new SqlConnection(scsb.ToString());
        }

    }

}
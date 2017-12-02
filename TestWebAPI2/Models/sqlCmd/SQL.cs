using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models.database;
using Models.blueprint.tableClass;

namespace Models.sqlCmd
{
    public class SQL
    {
        public static String tableName = "users";

        public static DataTable selectAll()
        {
            SqlConnection conn = Db.conn();
            conn.Open();
            string strSQL = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            var dt = new DataTable();
            dt.Load(reader);

            reader.Close();
            conn.Close();
            return dt;
        }

        public static DataTable selectOneRow<T>(String colName, T colVal)
        {
            SqlConnection conn = Db.conn();
            conn.Open();
            string strSQL =
                "SELECT TOP 1 * FROM " + tableName + " WHERE " + colName + " = @" + colName;
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@" + colName, colVal);
            SqlDataReader reader = cmd.ExecuteReader();

            var dt = new DataTable();
            dt.Load(reader);

            reader.Close();
            conn.Close();
            return dt;
        }


    }
}
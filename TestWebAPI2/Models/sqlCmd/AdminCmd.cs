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
    public class AdminCmd
    {
        public static String tableName = "admin";

        public static DataTable selectAll(string tableName)
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

        public static DataTable selectOne<T>(String colName, T colVal)
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


        public static void insert(Admin admin)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "INSERT INTO " + tableName +
                " (account,password,createAt,updateAt) VALUES(@account,@password,@createAt,@updateAt)";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@account", admin.account);
            cmd.Parameters.AddWithValue("@password", admin.password);
            cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
            int row = cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void delete(int adminID)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "DELETE FROM " + tableName +
                " WHERE adminID = @adminID ";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@adminID", adminID);
            int row = cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void updatePwd(Admin admin)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "UPDATE " + tableName +
                " set password= @password, updateAt = @updateAt WHERE adminID=@adminID";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@password", admin.password);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@adminID", admin.adminID);
            int row = cmd.ExecuteNonQuery();
            
            conn.Close();
        }



    }
}
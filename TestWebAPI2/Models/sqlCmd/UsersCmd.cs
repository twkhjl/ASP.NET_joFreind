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
    public class UsersCmd
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


        public static void insert(Users user)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "INSERT INTO " + tableName +
                " (email,password,createAt,updateAt) VALUES(@email,@password,@createAt,@updateAt)";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
            int row = cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void delete(int userID)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "DELETE FROM " + tableName +
                " WHERE userID = @userID ";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            int row = cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void updatePwd(Users user)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL = "UPDATE " + tableName +
                " set password= @password, updateAt = @updateAt WHERE userID=@userID ";

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@adminID", user.userID);
            int row = cmd.ExecuteNonQuery();
            
            conn.Close();
        }



    }
}
using custom.tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestEF_new.Models;

namespace custom.ADONET
{
    public class UsersCmd
    {
        public static int insert(users data)
        {
            SqlConnection conn = Db.conn();
            conn.Open();
            string strSQL =
               "Insert INTO users (email,nickname,password,gender,birthDate,createAt,updateAt) " +
               "VALUES(@email,@nickname,@password,@gender,@birthDate,@createAt,@updateAt)";

            SqlCommand cmd = new SqlCommand(strSQL, conn);

            cmd.Parameters.AddWithValue("email", data.email);
            cmd.Parameters.AddWithValue("nickname", data.nickname);
            cmd.Parameters.AddWithValue("password", data.password);
            cmd.Parameters.AddWithValue("gender", data.gender);
            cmd.Parameters.AddWithValue("birthDate", data.birthDate);
            cmd.Parameters.AddWithValue("createAt", data.createAt);
            cmd.Parameters.AddWithValue("updateAt", data.updateAt);

            int row = cmd.ExecuteNonQuery();

            conn.Close();
            return row;
        }

        public static int changeStatus(users data, int status)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL =
                " UPDATE users SET status =@status " +
                " WHERE userID=@userID";
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("userID", data.userID);
            cmd.Parameters.AddWithValue("status", status);
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public static int changePassword(users data)
        {
            SqlConnection conn = Db.conn();
            conn.Open();

            string strSQL =
                " UPDATE users SET password = @password " +
                " WHERE userID = @userID";
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.Parameters.AddWithValue("userID", data.userID);
            cmd.Parameters.AddWithValue("password", data.password);
            int row = cmd.ExecuteNonQuery();
            conn.Close();
            return row;
        }

    }
}
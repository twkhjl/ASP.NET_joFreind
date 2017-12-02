using Models.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Models.blueprint.tableClass;
using Models.sqlCmd;
using Models.helper;
using Models.blueprint.jsonClass;

namespace Models.factory
{
    public class UsersFactory
    {
        int position = 0;
        List<UsersJson> jsonList = new List<UsersJson>();


        //-----------show json data-----------
        public UsersFactory()
        {
            getData();
        }

        public UsersJson getCurrent()
        {
            return jsonList.Find(x => x.userID == position);
            
        }

        public UsersJson[] getAll()
        {
            return jsonList.ToArray();
        }

        public void moveTo(int p)
        {
            position = p;
        }

        public void moveToLast()
        {
            position = jsonList.Max(t => t.userID);
        }

        public void moveToFirst()
        {
            position = jsonList.Min(t => t.userID);
        }

        public void getData()
        {
            DataTable dt = UsersCmd.selectAll();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UsersJson obj = new UsersJson();

                obj.userID = (int)dt.Rows[i]["userID"];
                obj.email = dt.Rows[i]["email"].ToString();
                obj.authority = (int)dt.Rows[i]["authority"];
                obj.status = (int)dt.Rows[i]["status"];
                obj.createAt = String.Format("{0:yyyy/MM/dd tt HH:mm}", dt.Rows[i]["createAt"]);
                obj.updateAt = String.Format("{0:yyyy/MM/dd tt HH:mm}", dt.Rows[i]["updateAt"]);

                jsonList.Add(obj);
            }
        }

        //-----------edit db record----------


        public UsersJson addOne(Users user)
        {
            //hash password
            user.password = HashHelper.getHash(user.password);

            UsersCmd.insert(user);

            //use getData() to update list so that 
            //the getCurrent() method can return newest obj
            getData();
            moveToLast();
            return getCurrent();
        }

        //public void delOne(Admin admin)
        //{

        //    AdminCmd.delete(admin.userID);

        //    //use getData() to update list so that 
        //    getData();
        //    moveToLast();
        //}

        //public void updateOne(Admin admin)
        //{

        //    AdminCmd.delete(admin.userID);

        //    //use getData() to update list so that 
        //    getData();
        //    moveToLast();
        //}


    }
}
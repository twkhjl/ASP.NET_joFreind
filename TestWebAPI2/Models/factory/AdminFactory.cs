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
    public class AdminFactory
    {
        int position = 0;
        List<AdminJson> jsonList = new List<AdminJson>();


        //-----------show json data-----------
        public AdminFactory()
        {
            getData();
        }

        public AdminJson getCurrent()
        {
            return jsonList.Find(x => x.adminID == position);
            
        }

        public AdminJson[] getAll()
        {
            return jsonList.ToArray();
        }

        public void moveTo(int p)
        {
            position = p;
        }

        public void moveToLast()
        {
            position = jsonList.Max(t => t.adminID);
        }

        public void moveToFirst()
        {
            position = jsonList.Min(t => t.adminID);
        }

        public void getData()
        {
            DataTable dt = AdminCmd.selectAll("admin");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                AdminJson obj = new AdminJson();

                obj.adminID = (int)dt.Rows[i]["adminID"];
                obj.account = dt.Rows[i]["account"].ToString();
                obj.authority = (int)dt.Rows[i]["authority"];
                obj.status = (int)dt.Rows[i]["status"];
                obj.createAt = String.Format("{0:yyyy/MM/dd tt HH:mm}", dt.Rows[i]["createAt"]);
                obj.updateAt = String.Format("{0:yyyy/MM/dd tt HH:mm}", dt.Rows[i]["updateAt"]);

                jsonList.Add(obj);
            }
        }

        //-----------edit db record----------


        public AdminJson addOne(Admin admin)
        {
            //hash password
            admin.password = HashHelper.getHash(admin.password);

            AdminCmd.insert(admin);

            //use getData() to update list so that 
            //the getCurrent() method can return newest obj
            getData();
            moveToLast();
            return getCurrent();
        }

        public void delOne(Admin admin)
        {

            AdminCmd.delete(admin.adminID);

            //use getData() to update list so that 
            getData();
            moveToLast();
        }

        public void updateOne(Admin admin)
        {

            AdminCmd.delete(admin.adminID);

            //use getData() to update list so that 
            getData();
            moveToLast();
        }


    }
}
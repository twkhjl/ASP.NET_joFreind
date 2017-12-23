using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestEF_new.Models;

using custom.tools;
using custom.formClass.users;
using System.Web.Http.ModelBinding;
using System.Globalization;
using Models.email;
using custom.ADONET;


namespace TestEF_new.Controllers
{
    public class ActivityController : ApiController
    {
        private JofriendEntities db = new JofriendEntities();

        [HttpGet]
        [Route("api/activities")]
        public dynamic GetActivities()
        {

            var result =
            from activity in db.Activity
            join users in db.users on activity.UserID equals users.userID
            join category in db.Category on activity.CategoryID equals category.CategoryID
            select new {
                categoryID = activity.CategoryID,
                activityID = activity.ActivityID,
                userID = users.userID,
                userEmail = users.email,
                userNickName = users.nickname,
                categoryName = category.name,
                title = activity.Title,
                content = activity.Content,
                remarks = activity.Remarks,
                address = activity.Address,
                phone = activity.Phone,
                longitude = activity.Longitude,
                latitude = activity.Latitude,
                status = activity.Status,
                beginAt=activity.BeginAt,
                endAt=activity.EndAt
            };

            return result.ToArray();
        }

        [HttpGet]
        [Route("api/activities/category/id/{id}")]
        public dynamic getActivityByCategoryID(int id)
        {
            var result =
            from activity in db.Activity
            join users in db.users on activity.UserID equals users.userID
            join category in db.Category on activity.CategoryID equals category.CategoryID
            where activity.CategoryID == id
            select new
            {
                categoryID = activity.CategoryID,
                activityID = activity.ActivityID,
                userID = users.userID,
                userEmail = users.email,
                userNickName = users.nickname,
                categoryName = category.name,
                title = activity.Title,
                content = activity.Content,
                remarks = activity.Remarks,
                address = activity.Address,
                phone = activity.Phone,
                longitude = activity.Longitude,
                latitude = activity.Latitude,
                status = activity.Status,
                beginAt = activity.BeginAt,
                endAt = activity.EndAt
            };

            return result.ToArray();
        }

        [HttpGet]
        [Route("api/activity/id/{id}")]
        public dynamic getActivityByActivityID(int id)
        {
            var result =
            from activity in db.Activity
            join users in db.users on activity.UserID equals users.userID
            join category in db.Category on activity.CategoryID equals category.CategoryID
            where activity.ActivityID==id
            select new
            {
                categoryID = activity.CategoryID,
                activityID = activity.ActivityID,
                userID = users.userID,
                userEmail = users.email,
                userNickName = users.nickname,
                categoryName = category.name,
                title = activity.Title,
                content = activity.Content,
                remarks = activity.Remarks,
                address = activity.Address,
                phone = activity.Phone,
                longitude = activity.Longitude,
                latitude = activity.Latitude,
                status = activity.Status,
                beginAt = activity.BeginAt,
                endAt = activity.EndAt
            };

            return result.ToArray();
        }
        
    }
}

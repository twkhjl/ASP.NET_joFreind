using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestEF_new.custom.formClass.activities
{
    public class FormAddActivity
    {
        public int ActivityID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> FactoryID { get; set; }
        public string Title { get; set; }
        public Nullable<int> IsPublic { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Cost { get; set; }
        public Nullable<int> Points { get; set; }
        public string Tag { get; set; }
        public string Remarks { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public Nullable<System.DateTime> BeginAt { get; set; }
        public Nullable<System.DateTime> EndAt { get; set; }
        public Nullable<System.DateTime> CreateAt { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Content { get; set; }
        public string Longitude { get; set; }
    }
}
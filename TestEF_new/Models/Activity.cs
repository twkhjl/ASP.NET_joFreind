//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEF_new.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
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
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public Nullable<System.DateTime> BeginAt { get; set; }
        public Nullable<System.DateTime> EndAt { get; set; }
        public Nullable<System.DateTime> CreateAt { get; set; }
        public Nullable<System.DateTime> UpdateAt { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Content { get; set; }
    }
}

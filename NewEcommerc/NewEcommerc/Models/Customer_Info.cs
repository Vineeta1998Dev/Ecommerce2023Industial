//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewEcommerc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer_Info
    {
        public int CusId { get; set; }
        public Nullable<int> LoginID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string mob { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Crd { get; set; }
        public Nullable<int> CrdBy { get; set; }
        public Nullable<System.DateTime> Lmd { get; set; }
        public Nullable<int> LmdBy { get; set; }
    }
}

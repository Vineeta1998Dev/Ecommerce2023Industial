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
    
    public partial class Product
    {
        public int ProId { get; set; }
        public string productName { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Details { get; set; }
        public string TableDetails { get; set; }
        public Nullable<int> price { get; set; }
        public string MainImage { get; set; }
        public string Images { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<int> ProType { get; set; }
        public Nullable<int> ProCat { get; set; }
        public Nullable<int> ProSubCat { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> Crd { get; set; }
        public Nullable<int> Crdby { get; set; }
        public Nullable<System.DateTime> Lmd { get; set; }
        public Nullable<int> LmdBy { get; set; }
    }
}

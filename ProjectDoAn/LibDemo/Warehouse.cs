//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        public int Id { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> Size { get; set; }
        public string Color { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Status { get; set; }
        public string IsDelete { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Discount { get; set; }
    
        public virtual Product Product { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        public Warehouse()
        {
            this.Carts = new HashSet<Cart>();
            this.Imports = new HashSet<Import>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> IsDelete { get; set; }
        public Nullable<int> ProductImgId { get; set; }
        public Nullable<int> Discount { get; set; }
    
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ProductImg ProductImg { get; set; }
        public virtual Size Size { get; set; }
    }
}

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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> SaleId { get; set; }
        public string Code { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string AddressTo { get; set; }
        public string Phone { get; set; }
        public string BuyerName { get; set; }
        public string Note { get; set; }
        public string KeyCode { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> CustomerPay { get; set; }
        public string Refuse { get; set; }
        public Nullable<int> Type { get; set; }
    
        public virtual Province Province { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

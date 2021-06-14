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
    
    public partial class Product
    {
        public Product()
        {
            this.ProductImgs = new HashSet<ProductImg>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> IsDelete { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Type { get; set; }
        public string AvatarUrl { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImg> ProductImgs { get; set; }
    }
}

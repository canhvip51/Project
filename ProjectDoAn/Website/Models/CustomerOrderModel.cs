using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class CustomerOrderModel
    {
        public int Id { get; set; }
        public Nullable<int> Total { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string AccountNumber { get; set; }
        public string AddressFrom { get; set; }
        public string BuyerName { get; set; }
        public string Note { get; set; }
        public List<int> WarehouseId = new List<int>();
        public List<int> Amount = new List<int>();
        public List<string> Size = new List<string>();
        public List<string> ProductName = new List<string>();
        public List<int> MaxAmount = new List<int>();
        public List<int> Price = new List<int>();
        public List<string> Avatar = new List<string>();
    }
}
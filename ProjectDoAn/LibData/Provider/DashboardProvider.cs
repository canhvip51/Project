using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class DashboardProvider : ApplicationDbContexts
    {
        public int RevenueMonth(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Month == dateTime.Month).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int RevenueDay(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Day == dateTime.Day).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int RevenueYear(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Year == dateTime.Year).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<ModelReport> TopBestSale()
        {
            try
            {
                DateTime td = DateTime.Now.AddMonths(-3);
              
                var list = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH && x.Order.CreateDate > td).ToList();
                var a = list.GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                {
                    id=y.Key.Id,
                    amount = y.Sum(x => x.Amount.Value),
                }).ToList();
                
                return a.OrderByDescending(x=>x.amount).Skip(0).Take(3).ToList();
            }
            catch (Exception e)
            {
                return new List<ModelReport>();
            }
        }
        public List<ModelReport> TopBadSale()
        {
            try
            {
                DateTime td = DateTime.Now.AddMonths(-3);
           
                var list = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH && x.Order.CreateDate > td).ToList();
                var a = list.GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                {
                    id = y.Key.Id,
                    amount = y.Sum(x => x.Amount.Value),
                }).ToList();
                return a.OrderBy(x => x.amount).Skip(0).Take(3).ToList();
            }
            catch (Exception e)
            {
                return new List<ModelReport>();
            }
        }
        public List<Product> Stocking()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && x.ProductImgs.Count(y=> (y.IsDelete == 0 || y.IsDelete == null) && y.Warehouses.Count>0) >0).OrderByDescending(x=>x.ProductImgs.Sum(y=>y.Warehouses.Sum(m=>m.Amount))).Skip(0).Take(10).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> OutOfStock()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && x.ProductImgs.Count(y => (y.IsDelete == 0 || y.IsDelete == null) && y.Warehouses.Count > 0) > 0).OrderBy(x => x.ProductImgs.Sum(y => y.Warehouses.Sum(m => m.Amount))).Skip(0).Take(10).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> NotImport()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && x.ProductImgs.Count(y => (y.IsDelete == 0 || y.IsDelete == null) && (y.Warehouses.Count<1 || y.Warehouses.Count(m=>m.Amount==0 && m .Sold==0)>0)) > 0).OrderByDescending(x => x.CreateDate).Skip(0).Take(10).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
    }

    public class ModelReport{
       public int id { get; set; }
        public int amount { get; set; }
    }

}

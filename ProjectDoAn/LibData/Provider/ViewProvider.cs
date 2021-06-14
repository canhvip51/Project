using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class ViewProvider : ApplicationDbContexts
    {
        public List<Product> GetAllTopSale()
        {
            try
            {
                var a = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH).GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                {
                    id = y.Key.Id,
                    amount = y.Sum(x => x.Amount.Value),
                }).ToList();
                List<int> listid = a.Select(x => x.id).ToList();
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && listid.Contains(x.Id)
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count(m => (m.IsDelete == 0 || m.IsDelete == null)
                 && m.Warehouses.Count(n => n.Amount > 0) > 0) > 0).OrderByDescending(x => x.ProductImgs.Where(y => (y.IsDelete == 0 || y.IsDelete == null)).Sum(y => y.Warehouses.Sum(z => z.Amount))).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllTopSale()
        {
            try
            {
                var a = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH).GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                {
                    id = y.Key.Id,
                    amount = y.Sum(x => x.Amount.Value),
                }).ToList();
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && a.Select(y => y.id).Contains(x.Id)
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count(m => (m.IsDelete == 0 || m.IsDelete == null)
                 && m.Warehouses.Count(n => n.Amount > 0) > 0) > 0);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllTopSale(int skip, int size)
        {
            try
            {
                var a = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH).GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                {
                    id = y.Key.Id,
                    amount = y.Sum(x => x.Amount.Value),
                }).ToList();
                List<int> listid = a.Select(x => x.id).ToList();
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                && listid.Contains(x.Id)
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count(m => (m.IsDelete == 0 || m.IsDelete == null)
                 && m.Warehouses.Count(n => n.Amount > 0) > 0) > 0).OrderByDescending(x => x.ProductImgs.Where(y=> (y.IsDelete == 0 || y.IsDelete == null)).Sum(y=>y.Warehouses.Sum(z=>z.Sold))).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllTopSale(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (typeid != -1 ? x.Type == typeid : true)
                 && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllTopSale(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count > 0 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)
                 && (typeid != -1 ? x.Type == typeid : true)
                 ).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> GetAllProductNew()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count > 0).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductNew()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.ProductImgs.Count > 0);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductNew(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductNew(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)
                 && (typeid != -1 ? x.Type == typeid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductNew(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)
                 && (typeid != -1 ? x.Type == typeid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> GetAllProductDiscount()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0).OrderBy(x => x.Discount).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductDiscount()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0 && x.ProductImgs.Count > 0);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductDiscount(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductDiscount(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0 && x.Name.Contains(keysearch) && (typeid != -1 ? x.Type == typeid : true)
                 && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductDiscount(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0 && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> GetAllProductMale()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductMale()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductMale(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Type == (int)Configuration.ProductConfig.Type.MALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductMale(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Type == (int)Configuration.ProductConfig.Type.MALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductMale(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> GetAllProductFemale()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductFemale()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductFemale(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE && x.ProductImgs.Count > 0
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductFemale(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Type == (int)Configuration.ProductConfig.Type.FEMALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductFemale(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Type == (int)Configuration.ProductConfig.Type.FEMALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }

        //Brand
        public int CountAllProductByBrand(string keysearch, int typeid, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductByBrand(string keysearch, int typeid, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (typeid != -1 ? x.Type == typeid : true) && x.ProductImgs.Count > 0
                 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public List<Product> GetAllProductSimilar(int brandid, int type, int skip, int size)
        {
            try
            {
                //return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                //&& (x.IsDelete == null || x.IsDelete == 0) && (x.Type == type || x.BrandId == brandid) && x.ProductImgs.Count > 0
                //&& (x.ProductImgs.Count > 0 ? x.ProductImgs.Count(m => m.Warehouses.Count > 0) > 0 :)
                //).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && (x.Type == type || x.BrandId == brandid) && x.ProductImgs.Count > 0).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }

        //List VIew product
        public List<Product> GetAllByAllKey(string key, int brand, int sex, string sort,int sizeP, int skip, int size)
        {
            try
            {
              
               
                List<Product> products = ApplicationDbContext.Products.Where(x => x.Name.Contains(key) && (brand != -1 ? x.BrandId == brand : true)
                && (sex != -1 ? x.Type == sex : true) && x.Status == 1 && (x.IsDelete == null || x.IsDelete == 0)
                && x.ProductImgs.Count(m => m.Status == 1 && (m.IsDelete == 0 || m.IsDelete == null)) > 0).ToList();
                if (sizeP != -1)
                {
                    List<int> list = ApplicationDbContext.Warehouses.Where(x => (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status == 1
                    && x.Amount > 0 && x.SizeId==sizeP).Select(x => x.ProductImg.ProductId.Value).ToList();
                    products = products.Where(x => list.Contains(x.Id)).ToList();
                }
                if (sort == Configuration.ViewConfig.TOPSALE)
                {
                    var a = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH).GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                    {
                        id = y.Key.Id,
                        amount = y.Sum(x => x.Amount.Value),
                    }).ToList();
                    List<int> listid = a.Select(x => x.id).ToList();
                    products = products.Where(x=>listid.Contains(x.Id)).OrderByDescending(x => x.ProductImgs.Where(y =>listid.Contains(y.Id) && (y.IsDelete == 0 || y.IsDelete == null)).Sum(y => y.Warehouses.Sum(z => z.Sold))).ToList();
                }
                if (sort == Configuration.ViewConfig.PRODUCTNEW)
                {
                    products = products.OrderByDescending(x => x.ProductImgs.Max(m => m.CreateDate)).ToList();
                }
                if (sort == Configuration.ViewConfig.DISCOUNT)
                {
                    products = products.OrderByDescending(x => x.Discount > 0).ToList();
                }
                if (sort == Configuration.ViewConfig.PRICEUP)
                {
                    products = products.OrderBy(x => x.Price).ToList();
                }
                if (sort == Configuration.ViewConfig.PRICEDOWN)
                {
                    products = products.OrderByDescending(x => x.Price).ToList();
                }
                if (sort == Configuration.ViewConfig.ATOZ)
                {
                    products = products.OrderBy(x => x.Name).ToList();
                }
                if (sort == Configuration.ViewConfig.ZTOA)
                {
                    products = products.OrderByDescending(x => x.Name).ToList();
                }
                return products.Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllByAllKey(string key, int brand, int sex, string sort, int sizeP)
        {
            try
            {
               var products = ApplicationDbContext.Products.Where(x => x.Name.Contains(key) && (brand != -1 ? x.BrandId == brand : true)
                  && (sex != -1 ? x.Type == sex : true) && x.Status == 1 && (x.IsDelete == null || x.IsDelete == 0)
                  && x.ProductImgs.Count(m => m.Status == 1 && (m.IsDelete == 0 || m.IsDelete == null)) > 0);
                if (sizeP != -1)
                {
                    List<int> list = ApplicationDbContext.Warehouses.Where(x => (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status == 1
                    && x.Amount > 0 && x.SizeId == sizeP).Select(x => x.ProductImg.ProductId.Value).ToList();
                    products = products.Where(x => list.Contains(x.Id));
                }
                if (sort == Configuration.ViewConfig.TOPSALE)
                {
                    var a = ApplicationDbContext.OrderDetails.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Order.Status == (int)Configuration.OrderConfig.Status.FINISH).GroupBy(x => x.Warehouse.ProductImg.Product).Select(y => new ModelReport
                    {
                        id = y.Key.Id,
                        amount = y.Sum(x => x.Amount.Value),
                    }).ToList();
                    List<int> listid = a.Select(x => x.id).ToList();
                    products = products.Where(x => listid.Contains(x.Id)).OrderByDescending(x => x.ProductImgs.Where(y => listid.Contains(y.Id) && (y.IsDelete == 0 || y.IsDelete == null)).Sum(y => y.Warehouses.Sum(z => z.Amount)));
                }
                if (sort == Configuration.ViewConfig.PRODUCTNEW)
                {
                    products = products.OrderByDescending(x => x.ProductImgs.Max(m => m.CreateDate));
                }
                if (sort == Configuration.ViewConfig.DISCOUNT)
                {
                    products = products.OrderByDescending(x => x.Discount > 0);
                }
                if (sort == Configuration.ViewConfig.PRICEUP)
                {
                    products = products.OrderBy(x => x.Price);
                }
                if (sort == Configuration.ViewConfig.PRICEDOWN)
                {
                    products = products.OrderByDescending(x => x.Price);
                }
                if (sort == Configuration.ViewConfig.ATOZ)
                {
                    products = products.OrderBy(x => x.Name);
                }
                if (sort == Configuration.ViewConfig.ZTOA)
                {
                    products = products.OrderByDescending(x => x.Name);
                }
                return products.Count();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}

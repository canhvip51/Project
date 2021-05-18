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
                return ApplicationDbContext.Products.Where(x =>x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)).OrderByDescending(x => x.Sold).ToList();
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
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllTopSale(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)).OrderByDescending(x => x.Sold).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllTopSale(string keysearch, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllTopSale(string keysearch,int brandid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) &&(brandid!=-1?x.BrandId==brandid:true)
                 ).OrderByDescending(x => x.Sold).Skip(skip).Take(size).ToList();
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
                 && (x.IsDelete == null || x.IsDelete == 0)).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }
        public int CountAllProductNew()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductNew(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }
        public int CountAllProductNew(string keysearch, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductNew(string keysearch, int brandid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
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
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductDiscount(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductDiscount(string keysearch, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductDiscount(string keysearch, int brandid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Discount > 0 && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE).OrderBy(x => x.Discount).ToList();
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
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductMale(string keysearch, int brandid, int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
        public int CountAllProductMale(string keysearch, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
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
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.MALE).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE).OrderBy(x => x.Discount).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }
        public int CountAllProductFemale()
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductFemale( int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }
        public int CountAllProductFemale(string keysearch, int brandid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Product> GetAllProductFemale(string keysearch, int brandid, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type == (int)Configuration.ProductConfig.Type.FEMALE && x.Name.Contains(keysearch) && (brandid != -1 ? x.BrandId == brandid : true)).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }
    }
}

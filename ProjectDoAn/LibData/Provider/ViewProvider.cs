using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
   public class ViewProvider : ApplicationDbContexts
    {
        public List<ProductImg> GetAllTopSale()
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x =>x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)
                 && x.Product.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.Product.IsDelete == null && x.Product.IsDelete == 0)).OrderByDescending(x => x.Product.Sold).ToList();
            }
            catch (Exception e)
            {
                return new List<ProductImg>();
            }
        }
        public List<ProductImg> GetAllTopSale(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)
                 && x.Product.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.Product.IsDelete == null && x.Product.IsDelete == 0)).OrderByDescending(x => x.Product.Sold).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<ProductImg>();
            }
        }
        public List<ProductImg> GetAllProductNew()
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)
                 && x.Product.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.Product.IsDelete == null && x.Product.IsDelete == 0)).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return new List<ProductImg>() ;
            }
        }public List<ProductImg> GetAllProductNew(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0)
                 && x.Product.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.Product.IsDelete == null|| x.Product.IsDelete == 0)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<ProductImg>() ;
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
        }  public List<Product> GetAllProductDiscount(int skip,int size)
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
        public List<Product> GetAllProductMale()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type > (int)Configuration.ProductConfig.Type.MALE).OrderBy(x => x.Discount).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>();
            }
        }  public List<Product> GetAllProductMale(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type > (int)Configuration.ProductConfig.Type.MALE).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
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
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type > (int)Configuration.ProductConfig.Type.FEMALE).OrderBy(x => x.Discount).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }  public List<Product> GetAllProductFemale(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.Status == (int)Configuration.ProductConfig.Status.ACTIVE
                 && (x.IsDelete == null || x.IsDelete == 0) && x.Type > (int)Configuration.ProductConfig.Type.FEMALE).OrderBy(x => x.Discount).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return new List<Product>() ;
            }
        }
    }
}

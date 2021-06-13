using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class ProductProvider : ApplicationDbContexts
    {
        public bool Insert(Product model)
        {
            try
            {
                model.Sold = 0;
                model.Status = 1;
                model.CreateDate = DateTime.Now;
                ApplicationDbContext.Products.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Product model)
        {
            try
            {
                Product product = GetById(model.Id);
                product.AvatarUrl = model.AvatarUrl;
                product.Name = model.Name;
                product.Describe = model.Describe;
                //product.TypeShoeId = model.TypeShoeId;
                product.Origin = model.Origin;
                product.BrandId = model.BrandId;
                product.UpdateDate = DateTime.Now;
                product.Discount = model.Discount;
                product.Price = model.Price;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateStatus(Product model)
        {
            try
            {
                Product product = GetById(model.Id);
                product.Status = model.Status;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateSold(Product model)
        {
            try
            {
                Product product = GetById(model.Id);
                product.Sold = model.Sold;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                Product product = GetById(id);
                product.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Product GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Products.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Product> GetAll()
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<Product> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAll()
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Product> GetAllByKey(string key, int brandid, int sex, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Name.Contains(key)
                && (sex != -1 ? x.Type == sex : true)
                && (brandid != -1 ? x.BrandId.Value == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllByKey(string key, int brandid, int sex)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => (x.IsDelete == 0 || x.IsDelete == null
                && (brandid != -1 ? x.BrandId.Value == brandid : true)) && x.Name.Contains(key) && (sex != -1 ? x.Type == sex : true));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public bool DiscountProduct(List<int> productid, List<int> brandid, int discount)
        {
            try
            {
                var list = ApplicationDbContext.Products.Where(x => (productid.Count > 0 ? productid.Contains(x.Id) : true) || (brandid.Count > 0 ? brandid.Contains(x.BrandId.Value) : true)).ToList();
                list.ForEach(x => x.Discount = discount);
                list.ForEach(x => x.UpdateDate = DateTime.Now);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckNameAndType(string name, int type)
        {
            try
            {
                var product = ApplicationDbContext.Products.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null)
                && x.Name.Trim().ToLower() == name.Trim().ToLower() && x.Type == type);
                if (product != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

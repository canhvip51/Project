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
                product.Status = model.Status;
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
        public bool Update()
        {
            try
            {
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
                return ApplicationDbContext.Products.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Product> GetAllByKey(string key, int brandid, int sex,int status, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Name.Contains(key)
                && (sex != -1 ? x.Type == sex : true) && (status != -1 ? x.Status == status : true)
                && (brandid != -1 ? x.BrandId.Value == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllByKey(string key, int brandid, int sex,int status)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && (status != -1 ? x.Status == status : true)
                && (brandid != -1 ? x.BrandId.Value == brandid : true) && x.Name.Contains(key) && (sex != -1 ? x.Type == sex : true));
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
                var list = new List<Product>();
                if (productid.Count>0 && brandid.Count > 0)
                {
                     list = ApplicationDbContext.Products.Where(x => productid.Contains(x.Id)  ||  brandid.Contains(x.BrandId.Value)).ToList();
                    list.ForEach(x => x.Discount = discount);
                    list.ForEach(x => x.UpdateDate = DateTime.Now);
                    ApplicationDbContext.SaveChanges();
                    return true;
                }
                if (productid.Count > 0 && brandid.Count <1)
                {
                     list = ApplicationDbContext.Products.Where(x => productid.Contains(x.Id)).ToList();
                    list.ForEach(x => x.Discount = discount);
                    list.ForEach(x => x.UpdateDate = DateTime.Now);
                    ApplicationDbContext.SaveChanges();
                    return true;
                }
                if (productid.Count <1 && brandid.Count > 0)
                {
                     list = ApplicationDbContext.Products.Where(x =>  brandid.Contains(x.BrandId.Value)).ToList();
                    list.ForEach(x => x.Discount = discount);
                    list.ForEach(x => x.UpdateDate = DateTime.Now);
                    ApplicationDbContext.SaveChanges();
                    return true;
                }
                 list = ApplicationDbContext.Products.ToList();
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
        public bool CheckNameAndType(Product model)
        {
            try
            {
                var product = ApplicationDbContext.Products.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null)
                && x.Name.Trim().ToLower() == model.Name.Trim().ToLower() && x.Type == model.Type&& x.Id!=model.Id);
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

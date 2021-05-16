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
                product.Name = model.Name;
                product.Describe = model.Describe;
                //product.TypeShoeId = model.TypeShoeId;
                product.Origin = model.Origin;
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
        public List<Product> GetAllByKey(string key,int brandid, int typeid ,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Products.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Name.Contains(key)&& (typeid!=-1?x.TypeShoeId.Value==typeid:true) && (brandid != -1 ? x.BrandId.Value == brandid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllByKey(string key, int brandid, int typeid)
        {
            try
            {
                return ApplicationDbContext.Products.Count(x => (x.IsDelete == 0 || x.IsDelete == null && (typeid != -1 ? x.TypeShoeId.Value == typeid : true) && (brandid != -1 ? x.BrandId.Value == brandid : true)) && x.Name.Contains(key));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class BrandProvider : ApplicationDbContexts
    {
        public bool Insert(Brand model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                ApplicationDbContext.Brands.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Brand model)
        {
            try
            {
                Brand brand = GetById(model.Id);
                brand.Name = model.Name;
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
                Brand brand = GetById(id);
                brand.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Brand GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Brands.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Brand> GetAll()
        {
            try
            {
                return ApplicationDbContext.Brands.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<Brand> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Brands.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Brands.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public bool CheckName(string name)
        {
            try
            {
                var brand = ApplicationDbContext.Brands.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Name.Trim().ToLower() == name.Trim().ToLower());
                if (brand != null)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

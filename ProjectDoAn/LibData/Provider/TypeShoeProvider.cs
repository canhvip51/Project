using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
   public class TypeShoeProvider : ApplicationDbContexts
    {
        public bool Insert(TypeSho model)
        {
            try
            {
                model.Status = 1;
                model.CreateDate = DateTime.Now;
                ApplicationDbContext.TypeShoes.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(TypeSho model)
        {
            try
            {
                TypeSho typeSho = GetById(model.Id);
                typeSho.Name = model.Name;
                typeSho.UpdateDate = DateTime.Now;
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
                TypeSho typeSho = GetById(id);
                typeSho.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public TypeSho GetById(int id)
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<TypeSho> GetAll()
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<TypeSho> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
        public List<TypeSho> GetAllByKey(string key,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Where(x => (x.IsDelete == 0 || x.IsDelete == null)&&x.Name.Contains(key)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllByKey(string key)
        {
            try
            {
                return ApplicationDbContext.TypeShoes.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Name.Contains(key));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}

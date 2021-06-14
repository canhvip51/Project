using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class ImportProvider : ApplicationDbContexts
    {
        public bool Insert(Import model)
        {
            try
            {
                    ApplicationDbContext.Imports.Add(model);
                    ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Import model)
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
        public bool Delete(int id)
        {
            try
            {
                Import import = GetById(id);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Import GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Imports.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Import> GetAll()
        {
            try
            {
                return ApplicationDbContext.Imports.OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<Import> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Imports.OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Imports.Count();
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Import> GetAllByKey(int importunitid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Imports.Where(x => (importunitid>0 ? x.ImportUnitId == importunitid : true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAllByKey( int importunitid)
        {
            try
            {
                return ApplicationDbContext.Imports.Count(x => (importunitid>0? x.ImportUnitId == importunitid : true));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}

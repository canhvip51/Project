using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class ImportUnitProvider : ApplicationDbContexts
    {
        public bool Insert(ImportUnit model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                ApplicationDbContext.ImportUnits.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(ImportUnit model)
        {
            try
            {
                ImportUnit importUnit = GetById(model.Id);
                importUnit.Name = model.Name;
                importUnit.Phone = model.Phone;
                importUnit.Address = model.Address;
                importUnit.IsUpdate= DateTime.Now;
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
                ImportUnit importUnit = GetById(id);
                importUnit.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public ImportUnit GetById(int id)
        {
            try
            {
                return ApplicationDbContext.ImportUnits.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<ImportUnit> GetAll()
        {
            try
            {
                return ApplicationDbContext.ImportUnits.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<ImportUnit> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.ImportUnits.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.ImportUnits.Count(x => x.IsDelete == 0 || x.IsDelete == null);
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
                var importUnit= ApplicationDbContext.ImportUnits.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null)&&x.Name.Trim().ToLower()==name.Trim().ToLower());
                if (importUnit != null)
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

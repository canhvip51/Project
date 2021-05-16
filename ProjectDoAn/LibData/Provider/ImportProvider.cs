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
                model.CreateDate = DateTime.Now;
                Warehouse warehouse = new WarehouseProvider().GetById(model.WarehouseId.Value);
                warehouse.Amount += model.Amount;
                if(new WarehouseProvider().UpdateAmount(warehouse))
                {
                    ApplicationDbContext.Imports.Add(model);
                    ApplicationDbContext.SaveChanges();
                }
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
                Import import = GetById(model.Id);
                import.ImportUnitId = model.ImportUnitId;
                import.Amount = model.Amount;
                import.WarehouseId = model.WarehouseId;
                import.Price = model.Price;
                import.UpdateDate= DateTime.Now;
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
                import.IsDelete = 1;
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
                return ApplicationDbContext.Imports.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
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
                return ApplicationDbContext.Imports.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Imports.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Import> GetAllByKey(int warehouseid,int importunitid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Imports.Where(x => (x.IsDelete == 0 || x.IsDelete == null)&& (importunitid>0 ? x.ImportUnitId == importunitid : true)&&(warehouseid>0?x.WarehouseId==warehouseid:true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAllByKey(int warehouseid, int importunitid)
        {
            try
            {
                return ApplicationDbContext.Imports.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && (importunitid>0? x.ImportUnitId == importunitid : true) && (warehouseid>0? x.WarehouseId == warehouseid : true));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
   public class WarehouseProvider : ApplicationDbContexts
    {
        public bool Insert(Warehouse model)
        {
            try
            {
                model.Discount = 0;
                model.Amount = 0;
                model.Status = 1;
                model.CreateDate = DateTime.Now;
                ApplicationDbContext.Warehouses.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdateAmount(Warehouse model)
        {
            try
            {
                Warehouse warehouse = GetById(model.Id);
                warehouse.Amount = model.Amount;
                warehouse.UpdateDate = DateTime.Now;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Warehouse model)
        {
            try
            {
                Warehouse warehouse = GetById(model.Id);
                warehouse.Size = model.Size;
                //warehouse.Amount = model.Amount;
                warehouse.Discount = model.Discount;
                warehouse.UpdateDate = DateTime.Now;
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
        public bool Delete(int id)
        {
            try
            {
                Warehouse warehouse = GetById(id);
                warehouse.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Warehouse> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Warehouses.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Warehouses.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Warehouse> GetAllByKey(int productImg,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Warehouses.Where(x => (x.IsDelete == 0 || x.IsDelete == null)&&x.ProductImgId==productImg).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Warehouse> GetAllByKey(int productImg)
        {
            try
            {
                return ApplicationDbContext.Warehouses.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.ProductImgId == productImg).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllBykey(int productImg)
        {
            try
            {
                return ApplicationDbContext.Warehouses.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && x.ProductImgId == productImg);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public Warehouse GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Warehouses.FirstOrDefault(x=>x.Id==id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Warehouse> GetAll()
        {
            try
            {
                return ApplicationDbContext.Warehouses.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public bool CheckSize(Warehouse model){
            try
            {
                int count =  ApplicationDbContext.Warehouses.Count(x => (x.IsDelete == 0 || x.IsDelete == null)&& x.SizeId==model.SizeId && x.ProductImgId==model.ProductImgId);
                if (count > 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
        public Warehouse GetBySize( int ProductImgId,int SizeId)
        {
            try
            {
                return ApplicationDbContext.Warehouses.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null) && x.SizeId == SizeId && x.ProductImgId == ProductImgId);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public void UpdateCode()
        {
            ApplicationDbContext.Warehouses.ToList().ForEach(x => x.Code = x.ProductImg.ProductId.Value.ToString() + x.ProductImgId.Value.ToString() + x.SizeId.Value.ToString());
            ApplicationDbContext.SaveChanges();
        }
    }
}

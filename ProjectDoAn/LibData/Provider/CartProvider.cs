using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class CartProvider : ApplicationDbContexts
    {
        public void RemoveProductinCart(string key)
        {
            try
            {
                ApplicationDbContext.Carts.Where(x => x.KeyCode == key && x.Status == 1).ToList().ForEach(x => x.Status = 3);
                ApplicationDbContext.SaveChanges();
                return;
            }
            catch (Exception)
            {
                return;
            }

        }
        public Cart GetByProductAndKey(int wareId, int cookieId)
        {
            try
            {
                return ApplicationDbContext.Carts.FirstOrDefault(x => x.WarehouseId == wareId && x.CookieId == cookieId && x.Status == 1 && (x.IsDelete == 1 || x.IsDelete == null));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Cart GetByProductAndKey(int id, string key)
        {
            try
            {
                return ApplicationDbContext.Carts.FirstOrDefault(x => x.WarehouseId == id && x.Status == 1 && x.Cookie.KeyCode== key);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Cart GetById(int Id)
        {
            try
            {
                return ApplicationDbContext.Carts.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Cart> GetAllByKey(string key)
        {
            try
            {
                return ApplicationDbContext.Carts.Where(x => x.Cookie.KeyCode == key && x.Cookie.ExpiredDate > DateTime.Now && ( x.IsDelete == null || x.IsDelete == 0)&&x.Status==Configuration.CartConfig.INCART).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Insert(Cart cart)
        {
            try
            {
                ApplicationDbContext.Carts.Add(cart);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(Cart cart)
        {
            try
            {
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int GetAmount(int wareid)
        {
            try
            {
                return ApplicationDbContext.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && x.WarehouseId.Value == wareid && x.Status.Value == 1 && (x.IsDelete.Value == 1 || x.IsDelete == null)).Sum(x => x.Amount.Value);
            }
            catch (Exception e)
            {
                return 0;
            }
           
        }
    }
}

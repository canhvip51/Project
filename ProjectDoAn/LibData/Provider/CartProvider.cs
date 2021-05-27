using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class CartProvider:ApplicationDbContexts
    {
        public void RemoveProductinCart(string key)
        {
            try
            {
               ApplicationDbContext.Carts.Where(x => x.KeyCode == key && x.Status == 1).ToList().ForEach(x=>x.Status=3);
                ApplicationDbContext.SaveChanges();
                return;
            }
            catch (Exception)
            {

                throw;
            }
            return;
        }
        public Cart GetByProductAndKey(int wareId, int cookieId)
        {
            try
            {
               return  ApplicationDbContext.Carts.FirstOrDefault(x=>x.WarehouseId==wareId && x.CookieId == cookieId && x.Status==1 &&( x.IsDelete==1 || x. IsDelete==null));
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
                return ApplicationDbContext.Carts.FirstOrDefault(x => x.WarehouseId == id && x.Status == 1 && x.KeyCode == key);
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
                return ApplicationDbContext.Carts.FirstOrDefault(x => x.Id==Id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Insert(Cart  cart)
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
    }
}

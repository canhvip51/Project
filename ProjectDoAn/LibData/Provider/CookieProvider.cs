using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class CookieProvider : ApplicationDbContexts
    {
        public Cookie GetByKey(string key)
        {
            try
            {
                return ApplicationDbContext.Cookies.FirstOrDefault(x => x.KeyCode == key && x.ExpiredDate > DateTime.Now);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Cookie GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Cookies.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Insert(Cookie cookie)
        {
            try
            {
                ApplicationDbContext.Cookies.Add(cookie);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Cookie cookie)
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
        public bool Remove(Cookie cookie)
        {
            try
            {
                ApplicationDbContext.Carts.RemoveRange(cookie.Carts);
                ApplicationDbContext.Cookies.Remove(cookie);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool RemoveAll()
        {
            try
            {
                ApplicationDbContext.Carts.RemoveRange(ApplicationDbContext.Carts.ToList());
                ApplicationDbContext.Cookies.RemoveRange(ApplicationDbContext.Cookies.ToList());
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Remove(int id)
        {
            try
            {
                Cookie cookie = GetById(id);
                if(cookie!=null){
                    ApplicationDbContext.Carts.RemoveRange(ApplicationDbContext.Carts.ToList());
                    ApplicationDbContext.Cookies.RemoveRange(ApplicationDbContext.Cookies.ToList());
                    ApplicationDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool RemoveAllExpired()
        {
            try
            {
                List<Cookie> cookies = ApplicationDbContext.Cookies.Where(x => x.ExpiredDate<DateTime.Now).ToList();
                ApplicationDbContext.Carts.RemoveRange(ApplicationDbContext.Carts.Where(x=>cookies.Select(m=>m.Id).Contains(x.CookieId.Value)).ToList());
                ApplicationDbContext.Cookies.RemoveRange(cookies);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(string key)
        {
            try
            {
                var old = GetByKey(key);
                old.ExpiredDate = DateTime.Now;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(int id)
        {
            try
            {
                var old = GetById(id);
                old.ExpiredDate = DateTime.Now;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

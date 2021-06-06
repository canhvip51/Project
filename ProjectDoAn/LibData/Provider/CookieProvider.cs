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

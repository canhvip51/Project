using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class OrderProvider : ApplicationDbContexts
    {
        public bool Insert(Order model)
        {
            try
            {
                ApplicationDbContext.Orders.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(Order model)
        {
            try
            {
                Order order = GetById(model.Id);
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
                Order order = GetById(id);
                order.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Order GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Orders.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<Order> GetAll()
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<Order> GetAll(int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Orders.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Order> GetAllByKey(string key,int status,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x =>( x.IsDelete == 0 || x.IsDelete == null)&&(x.BuyerName.Contains(key)||x.Phone.Contains(key))&&(status!=-1?x.Status==status:true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAllByKey(string key, int status)
        {
            try
            {
                return ApplicationDbContext.Orders.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && (x.BuyerName.Contains(key) || x.Phone.Contains(key)) && (status != -1 ? x.Status == status : true));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public bool CheckPhoneUserKey(string phone , string key)
        {
            try
            {
                LibData.Order order= ApplicationDbContext.Orders.FirstOrDefault(x => (x.IsDelete == 0 || x.IsDelete == null) && x.KeyCode.Equals(key) && x.Phone.Equals(phone));
                if (order != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Order> GetAllByPhone(string phone,int skip,int size)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x =>x.Phone.Equals(phone) && (x.OrderDetails.Where(m=>m.IsDelete == null || m.IsDelete.Value == 0).Sum(m=>m.Amount.Value)>0) && (x.IsDelete==null|| x.IsDelete==0)).OrderByDescending(x=>x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int  CountAllByPhone(string phone)
        {
            try
            {
                return ApplicationDbContext.Orders.Count(x => x.Phone.Equals(phone) && (x.OrderDetails.Where(m=>m.IsDelete == null || m.IsDelete == 0).Sum(m=>m.Amount.Value) > 0) && (x.IsDelete == null || x.IsDelete == 0));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public int CountOrderByStatus(int status)
        {
            try
            {
                return ApplicationDbContext.Orders.Count(x => (x.Status.Value == status)&&(x.IsDelete==null||x.IsDelete==0));
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}

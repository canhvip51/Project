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
                Order order = GetById(id);
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
                return ApplicationDbContext.Orders.OrderByDescending(x => x.CreateDate).ToList();
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
                return ApplicationDbContext.Orders.OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Orders.Count();
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<Order> GetAllByKey(string key,int status,int type,int paid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x =>(paid!=-1?(paid==(int)Configuration.OrderConfig.Pay.PAID? x.CustomerPay > x.Total: x.CustomerPay < x.Total) :true) 
                && (type != -1 ? x.Type == type : true) && (x.BuyerName.Contains(key)||x.Phone.Contains(key))
                &&(status!=-1?x.Status==status:true)).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAllByKey(string key, int status, int type, int paid)
        {
            try
            {
                return ApplicationDbContext.Orders.Count(x => (paid != -1 ? (paid == (int)Configuration.OrderConfig.Pay.PAID ? x.CustomerPay > x.Total : x.CustomerPay < x.Total) : true)
                && (type != -1 ? x.Type == type : true) && (x.BuyerName.Contains(key) || x.Phone.Contains(key))
                && (status != -1 ? x.Status == status : true));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public int GetTotalMoney(string key, int status, int type, int paid)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => (paid != -1 ? (paid == (int)Configuration.OrderConfig.Pay.PAID ? x.CustomerPay > x.Total : x.CustomerPay < x.Total) : true)
                && (type != -1 ? x.Type == type : true) && (x.BuyerName.Contains(key) || x.Phone.Contains(key))
                && (status != -1 ? x.Status == status : true)).Sum(x=>x.Total.Value);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public int CountAllByStatus( int status)
        {
            try
            {
                return ApplicationDbContext.Orders.Count(x =>(status != -1 ? x.Status == status : true));
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
                LibData.Order order= ApplicationDbContext.Orders.FirstOrDefault(x =>  x.KeyCode.Equals(key) && x.Phone.Equals(phone));
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
                return ApplicationDbContext.Orders.Where(x =>x.Phone.Equals(phone) && (x.OrderDetails.Where(m=>m.IsDelete == null || m.IsDelete.Value == 0).Sum(m=>m.Amount.Value)>0)).OrderByDescending(x=>x.CreateDate).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.Orders.Count(x => x.Phone.Equals(phone) && (x.OrderDetails.Where(m=>m.IsDelete == null || m.IsDelete == 0).Sum(m=>m.Amount.Value) > 0));
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
                return ApplicationDbContext.Orders.Count(x => (x.Status.Value == status));
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}

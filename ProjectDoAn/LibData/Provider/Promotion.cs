using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
  public  class Promotion : ApplicationDbContexts
    {
        public int GetDiscountByKeyCode(string key)
        {
            try
            {
                return ApplicationDbContext.Promotions.FirstOrDefault(x => x.KeyCode == key && x.ExpiredDate < DateTime.Now && (x.Amount.HasValue?x.Amount>0:true)).Discount.Value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public bool Insert( LibData.Promotion model)
        {
            try
            {
                ApplicationDbContext.Promotions.Add(model);
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
    }
}

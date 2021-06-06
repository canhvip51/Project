using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
  public  class PromotionProvider : ApplicationDbContexts
    {
        public int GetDiscountByKeyCode(string key)
        {
            try
            {
                return ApplicationDbContext.Promotions.FirstOrDefault(x => x.KeyCode == key &&(x.ExpiredDate.HasValue? x.ExpiredDate > DateTime.Now:true) && (x.StartDate.HasValue ? x.StartDate < DateTime.Now : true) && (x.Amount.HasValue?x.Amount>0:true)).Discount.Value;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public Promotion GetByKeyCode(string key)
        {
            try
            {
                return ApplicationDbContext.Promotions.FirstOrDefault(x => x.KeyCode == key && (x.ExpiredDate.HasValue ? x.ExpiredDate > DateTime.Now : true) && (x.StartDate.HasValue ? x.StartDate < DateTime.Now : true) && (x.Amount.HasValue ? x.Amount.Value > 0 : true));
            }
            catch (Exception e)
            {
                return null;
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

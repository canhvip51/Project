using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class OrderDetailProvider : ApplicationDbContexts
    {
        public int GetAmountWait(int id)
        {
            try
            {
                return ApplicationDbContext.OrderDetails.Where(x => x.WarehouseId == id && (x.IsDelete==null||x.IsDelete==0) && x.Order.Status==(int)Configuration.OrderConfig.Status.WAIT).Sum(x => x.Amount.Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool InsertAll(List<LibData.OrderDetail> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ApplicationDbContext.OrderDetails.Add(item);
                }
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

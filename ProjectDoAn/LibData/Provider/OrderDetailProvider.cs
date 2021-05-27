using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class OrderDetailProvider : ApplicationDbContexts
    {
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

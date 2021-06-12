using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class DashboardProvider : ApplicationDbContexts
    {
        public int RevenueMonth(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => (x.IsDelete == 0 || x.IsDelete == null)
               && x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Month== dateTime.Month).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int RevenueDay(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => (x.IsDelete == 0 || x.IsDelete == null)
               && x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Day == dateTime.Day).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int RevenueYear(DateTime dateTime)
        {
            try
            {
                return ApplicationDbContext.Orders.Where(x => (x.IsDelete == 0 || x.IsDelete == null)
               && x.Status == (int)Configuration.OrderConfig.Status.FINISH && x.UpdateDate.Value.Year == dateTime.Year).Sum(x => x.Total.Value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;
using LibData.Configuration;
//using System.Globalization;


namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("SuperAdmin")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DashboardOrder()
        {
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            Models.DashboardOrderModel dashboardOrderModel = new Models.DashboardOrderModel();
            dashboardOrderModel.CountWait = orderProvider.CountAllByStatus( (int)LibData.Configuration.OrderConfig.Status.WAIT);
            dashboardOrderModel.CountCancel = orderProvider.CountAllByStatus((int)LibData.Configuration.OrderConfig.Status.CANCEL);
            dashboardOrderModel.CountConfirm = orderProvider.CountAllByStatus( (int)LibData.Configuration.OrderConfig.Status.CONFIRM);
            dashboardOrderModel.CountFinish = orderProvider.CountAllByStatus((int)LibData.Configuration.OrderConfig.Status.FINISH);
            return View(dashboardOrderModel);
        }
        public ActionResult DashboardRevenue()
        {
            LibData.Provider.DashboardProvider dashboardProvider = new LibData.Provider.DashboardProvider();
            List<string> lable = new List<string>();
            List<string> result = new List<string>();
            List<string> color = new List<string>();
            DateTime dt = DateTime.Now;
            //DateTime ss = CultureInfo.CurrentCulture.GetFirstDayOfWeek
            Models.DashboardModel dashboardModel = new Models.DashboardModel();
            lable.Add("Doanh thu ngày " + dt.ToString("dd-MM-yyyy"));
            result.Add(dashboardProvider.RevenueDay(dt).ToString());
            lable.Add("Doanh thu tháng " + dt.ToString("MM"));
            result.Add(dashboardProvider.RevenueMonth(dt).ToString());
            lable.Add("Doanh thu năm " + dt.ToString("yyyy"));
            result.Add(dashboardProvider.RevenueYear(dt).ToString());
            Random r = new Random();
            int k = r.Next(1, 10);
            foreach (var item in lable)
            {  
                int p = r.Next(1, 10);
                k =(k+ p)%ColorConfig.Color.Count;
               color.Add(ColorConfig.Color[k]);
            }
            dashboardModel.lable = lable;
            dashboardModel.result = result;
            dashboardModel.color = color;
            return View(dashboardModel);
        }
    }
}
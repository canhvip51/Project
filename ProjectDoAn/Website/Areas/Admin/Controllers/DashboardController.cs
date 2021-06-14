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
            dashboardOrderModel.CountWait = orderProvider.CountAllByStatus( (int)OrderConfig.Status.WAIT);
            dashboardOrderModel.CountCancel = orderProvider.CountAllByStatus((int)OrderConfig.Status.CANCEL);
            dashboardOrderModel.CountConfirm = orderProvider.CountAllByStatus( (int)OrderConfig.Status.CONFIRM);
            dashboardOrderModel.CountFinish = orderProvider.CountAllByStatus((int)OrderConfig.Status.FINISH);
            return View(dashboardOrderModel);
        }
        public ActionResult DashboardRevenue()
        {
            LibData.Provider.DashboardProvider dashboardProvider = new LibData.Provider.DashboardProvider();
            List<string> lable = new List<string>();
            List<dynamic> result = new List<dynamic>();
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
            foreach (var item in result)
            {  
                int p = r.Next(1, 10);
                k =(k+ p)%ExtendConfig.Color.Count;
               color.Add(ExtendConfig.Color[k]);
            }
            dashboardModel.lable = lable;
            dashboardModel.result = result;
            dashboardModel.color = color;
            return View(dashboardModel);
        }
        public ActionResult DashboardProductSold()
        {
            LibData.Provider.DashboardProvider dashboardProvider = new LibData.Provider.DashboardProvider();
            List<string> lable = new List<string>();
            List<dynamic> result = new List<dynamic>();
            List<string> color = new List<string>();
            DateTime dt = DateTime.Now;
            Models.DashboardModel dashboardModel = new Models.DashboardModel();
            lable.Add("Top 3 sản phẩm bán nhiều trong 3 tháng");
            result.Add(dashboardProvider.TopBestSale());
            lable.Add("Top 3 sản phẩm bán ít nhât trong 3 tháng");
            result.Add(dashboardProvider.TopBadSale());
            Random r = new Random();
            int k = r.Next(1, 10);
            foreach (var item in result)
            {
                int p = r.Next(1, 10);
                k = (k + p) % ExtendConfig.Color.Count;
                color.Add(ExtendConfig.Color[k]);
            }
            dashboardModel.lable = lable;
            dashboardModel.result = result;
            dashboardModel.color = color;
            return View(dashboardModel);
        }
        public ActionResult DashboardInventory()
        {
            LibData.Provider.DashboardProvider dashboardProvider = new LibData.Provider.DashboardProvider();
            List<string> lable = new List<string>();
            List<dynamic> result = new List<dynamic>();
            List<string> color = new List<string>();
            DateTime dt = DateTime.Now;
            Models.DashboardModel dashboardModel = new Models.DashboardModel();
            lable.Add("Sản phẩm còn nhiều");
            result.Add(dashboardProvider.Stocking());
            lable.Add("Sản phẩm sắp hết");
            result.Add(dashboardProvider.OutOfStock());
            lable.Add("Sản phẩm chưa nhập hàng");
            result.Add(dashboardProvider.NotImport());
            Random r = new Random();
            int k = r.Next(1, 10);
            foreach (var item in result)
            {
                int p = r.Next(1, 10);
                k = (k + p) % ExtendConfig.Color.Count;
                color.Add(ExtendConfig.Color[k]);
            }
            dashboardModel.lable = lable;
            dashboardModel.result = result;
            dashboardModel.color = color;
            return View(dashboardModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;


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
            dashboardOrderModel.CountWait = orderProvider.CountAllByKey("", (int)LibData.Configuration.OrderConfig.Status.WAIT);
            dashboardOrderModel.CountCancel = orderProvider.CountAllByKey("", (int)LibData.Configuration.OrderConfig.Status.CANCEL);
            dashboardOrderModel.CountConfirm = orderProvider.CountAllByKey("", (int)LibData.Configuration.OrderConfig.Status.CONFIRM);
            dashboardOrderModel.CountFinish = orderProvider.CountAllByKey("", (int)LibData.Configuration.OrderConfig.Status.FINISH);
            return View(dashboardOrderModel);
        }
    }
}
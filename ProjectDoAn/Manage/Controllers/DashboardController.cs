using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vbot.Web.Infrastructure;

namespace Manage.Controllers
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
    }
}
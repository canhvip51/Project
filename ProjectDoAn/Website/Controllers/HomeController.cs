using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["Sliders"] = new LibData.Provider.SlideProvider().getAll();
            return View(new LibData.Provider.SanPhamProvider().getAllBySize(8));
        }
    }
}
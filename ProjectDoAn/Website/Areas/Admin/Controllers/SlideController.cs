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
    public class SlideController : Controller
    {
        // GET: Slide
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListSlide()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddSlide()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlide(LibData.Slide model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangeOrder(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangeOrder(int id, int replaceorderid)
        {
            return View();
        }
    }
}
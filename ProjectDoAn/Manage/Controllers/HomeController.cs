using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FroalaUploadImage(HttpPostedFileBase file, int? postId) 
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/Images/Upload/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "/Images/Upload/"+fileName }, JsonRequestBehavior.AllowGet);
        }
    }
}
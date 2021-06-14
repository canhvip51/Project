using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("SuperAdmin")]
    public class ExtendController : Controller
    {
        // GET: Extend
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SelectProvice(int? selectedp)
        {
            ViewBag.selectedp = selectedp;
            return View(new LibData.Provider.ExtendProvider().GetAddProvice());
        }
       
        public List<LibData.Province> ListProvice(int? selectedp)
        {
            ViewBag.selectedp = selectedp;
            return new LibData.Provider.ExtendProvider().GetAddProvice();
        }
      
        public ActionResult SelectSize(int? productimgid, int? selecteds,string list)
        {
            if (string.IsNullOrEmpty(list))
                list = "0";
            List<string> listDatas = list.Split(',').ToList();
            ViewBag.listDatas = listDatas;
            int type = new LibData.Provider.ProductImgProvider().GetById(productimgid.Value).Product.Type.Value;
            ViewBag.Type = type;
            ViewBag.selecteds = selecteds??-1;
            return View(new LibData.Provider.SizeProvider().GetAllBySex(type));
        }
        public ActionResult FroalaUploadImage(HttpPostedFileBase file, int? postId)
        {
            var fileName = Path.GetFileName(file.FileName);
            var rootPath = Server.MapPath("~/Images/Upload/");
            file.SaveAs(Path.Combine(rootPath, fileName));
            return Json(new { link = "/Images/Upload/" + fileName }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PrintOrder(int orderid)
        {

            return View( new LibData.Provider.OrderProvider().GetById(orderid));
        }
        public int CoutOrder(int status)
        {
            return new LibData.Provider.OrderProvider().CountOrderByStatus(status);
        }
    }
}
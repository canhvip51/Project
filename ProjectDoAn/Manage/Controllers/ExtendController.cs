using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vbot.Web.Infrastructure;

namespace Manage.Controllers
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
        public ActionResult SelectDistrict(int? id,int? selectedd)
        {
            ViewBag.ProvinceId = id;
            ViewBag.selectedd = selectedd??1;
            id = id ?? 0;
            return View(new LibData.Provider.ExtendProvider().GetAddDistricts(id.Value));
        }
        public ActionResult SelectWard(int? id, int? selectedw)
        {
            ViewBag.DistrictId = id;
            ViewBag.selectedw = selectedw?? 1;
            id = id ?? 0;
            return View(new LibData.Provider.ExtendProvider().GetAddWard(id.Value));
        }
        public List<LibData.Province> ListProvice(int? selectedp)
        {
            ViewBag.selectedp = selectedp;
            return new LibData.Provider.ExtendProvider().GetAddProvice();
        }
        public List<LibData.District> ListDistrict(int id, int? selectedd)
        {
            ViewBag.selectedp = selectedd;
            return new LibData.Provider.ExtendProvider().GetAddDistricts(id);
        }
        public List<LibData.Ward> ListWard(int id, int? selectedw)
        {
            ViewBag.selectedp = selectedw;
            return new LibData.Provider.ExtendProvider().GetAddWard(id);
        }
        public ActionResult SelectSize(int? productimgid, int? selecteds)
        {
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
    }
}
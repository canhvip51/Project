using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class SliderController : Controller
    {
        public const string _ImagesPath = "~/Images/Slider";
        // GET: Slider
        public ActionResult Index()
        {
            return View(new LibData.Provider.SliderProvider().getAll());
        }
        public ActionResult Create()
        {
            return View(new LibData.Slider());
        }
        [HttpPost]
        public ActionResult Create(LibData.Slider model, HttpPostedFileBase TenFile)
        {
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.Mota))
            {
                ModelState.AddModelError("Mota", "Vui lòng nhập giá trị");
            }
            if (TenFile == null)
            {
                ModelState.AddModelError("TenFile", "Vui lòng chọn file");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                string fileName = Guid.NewGuid() + Path.GetFileName(TenFile.FileName);
                string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                TenFile.SaveAs(path);
                model.TenFile = fileName;
                new LibData.Provider.SliderProvider().Insert(model);
                return RedirectToAction("Index", "Slider");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            return View(new LibData.Provider.SliderProvider().getById(id));
        }
        [HttpPost]
        public ActionResult Edit(LibData.Slider model, HttpPostedFileBase TenFile)
        {
           
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.Mota))
            {
                ModelState.AddModelError("Mota", "Vui lòng nhập giá trị");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Delete exiting file
            try
            {
                if (TenFile != null)
                {
                    var modelcur = new LibData.Provider.SliderProvider().getById(model.Id);
                    System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPath), modelcur.TenFile));
                    // Save new file
                    string fileName = Guid.NewGuid() + Path.GetFileName(TenFile.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    TenFile.SaveAs(path);
                    model.TenFile = fileName;
                }
                new LibData.Provider.SliderProvider().Update(model);
                return RedirectToAction("Index", "Slider");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
        }

    }
}
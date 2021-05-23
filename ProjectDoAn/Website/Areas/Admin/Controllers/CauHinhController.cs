using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class CauHinhController : Controller
    {
        // GET: CauHinh
        public ActionResult Index()
        {
            return View(new LibData.Provider.CauHinhProvider().getAll());
        }
       
        public ActionResult Create()
        {
            return View(new LibData.CauHinh());
        }
        [HttpPost]
        public ActionResult Create(LibData.CauHinh model)
        {
            //validate 
            if (string.IsNullOrEmpty(model.TenCauHinh))
            {
                ModelState.AddModelError("TenCauHinh", "TenCauHinh  Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.Giatri))
            {
                ModelState.AddModelError("Giatri", " Giatri Vui lòng nhập giá trị");
            }
            if (!ModelState.IsValid) {
                return View(model);
            }
            try
            {
                new LibData.Provider.CauHinhProvider().Insert(model);
                return RedirectToAction("Index", "CauHinh");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            return View(new LibData.Provider.CauHinhProvider().getById(id));
        }
        [HttpPost]
        public ActionResult Edit(LibData.CauHinh model)
        {
            if (string.IsNullOrEmpty(model.TenCauHinh))
            {
                ModelState.AddModelError("TenCauHinh", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.Giatri))
            {
                ModelState.AddModelError("Giatri", "Vui lòng nhập giá trị");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                new LibData.Provider.CauHinhProvider().Update(model);
                return RedirectToAction("Index", "CauHinh");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }


        }
    }
}
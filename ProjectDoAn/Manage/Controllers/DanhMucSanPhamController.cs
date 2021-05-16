using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: DanhMucSanPham
        public ActionResult Index()
        {
            return View(new LibData.Provider.DanhMucSanPhamProvider().getAll());
        }
        public ActionResult Create()
        {
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll(); 
            return View(new LibData.DanhMucSanPham());
        }
        [HttpPost]
        public ActionResult Create(LibData.DanhMucSanPham model)
        {
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            if (string.IsNullOrEmpty(model.TenDanhMuc))
            {
                ModelState.AddModelError("TenDanhMuc", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            if (model.STT==0)
            {
                ModelState.AddModelError("STT", "Vui lòng nhập giá trị >0");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                new LibData.Provider.DanhMucSanPhamProvider().Insert(model);
                return RedirectToAction("Index", "DanhMucSanPham");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
            
          
        }
        public ActionResult Edit(int id)
        {
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            return View(new LibData.Provider.DanhMucSanPhamProvider().getbyId(id));

        }
        [HttpPost]
        public ActionResult Edit(LibData.DanhMucSanPham model)
        {
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            if (string.IsNullOrEmpty(model.TenDanhMuc))
            {
                ModelState.AddModelError("TenDanhMuc", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            if (model.STT == 0)
            {
                ModelState.AddModelError("STT", "Vui lòng nhập giá trị >0");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                new LibData.Provider.DanhMucSanPhamProvider().Update(model);
                return RedirectToAction("Index", "DanhMucSanPham");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
           
        }
    }
}
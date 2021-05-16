using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class ThuongHieuController : Controller
    {
        // GET: ThuongHieu
        public ActionResult Index()
        {
            return View(new LibData.Provider.ThuongHieuProvider().getAll());
        }
        public ActionResult Create()
        {

            return View(new LibData.ThuongHieu());
        }
        [HttpPost]
        public ActionResult Create(LibData.ThuongHieu model)
        {
           
            if (string.IsNullOrEmpty(model.TenThuongHieu))
            {
                ModelState.AddModelError("TenThuongHieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.XuatXuThuongHieu))
            {
                ModelState.AddModelError("XuatXuThuongHieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.SanXuatTai))
            {
                ModelState.AddModelError("SanXuatTai", "Vui lòng nhập giá trị");
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {

                new LibData.Provider.ThuongHieuProvider().Insert(model);
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
            return View(new LibData.Provider.ThuongHieuProvider().getById(id));
        }
        [HttpPost]
        public ActionResult Edit(LibData.ThuongHieu model)
        {
            if (string.IsNullOrEmpty(model.TenThuongHieu))
            {
                ModelState.AddModelError("TenThuongHieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.XuatXuThuongHieu))
            {
                ModelState.AddModelError("XuatXuThuongHieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.SanXuatTai))
            {
                ModelState.AddModelError("SanXuatTai", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.MoTa))
            {
                ModelState.AddModelError("MoTa", "Vui lòng nhập giá trị");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                new LibData.Provider.ThuongHieuProvider().Insert(model);
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
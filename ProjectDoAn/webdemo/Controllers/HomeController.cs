using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibDemo;
namespace webdemo.Controllers
{
    public class HomeController : Controller
    {
        private SanphamProvider provider = new SanphamProvider();
        // GET: Home
        public ActionResult Index()
        {
            List<SanPham> models = new List<SanPham>();
            models = provider.getAll();
            return View(models);
        }
        public ActionResult Create()
        {
            SanPham model = new SanPham();
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(SanPham model)
        {
            if (string.IsNullOrEmpty(model.TenSanPham))
            {
                ModelState.AddModelError("TenSanPham", "Vui lòng nhập giá trị");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
        public ActionResult Create2()
        {
            CauHinh model = new CauHinh();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create2(CauHinh model)
        {
            if (string.IsNullOrEmpty(model.TenCauHinh))
            {
                ModelState.AddModelError("TenCauHinh", "Vui lòng nhập giá trị");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}
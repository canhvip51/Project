using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class HinhAnhSanPhamController : Controller
    {
        // GET: HinhAnhSanPham
        public ActionResult Index()
        {
            return View(new LibData.Provider.HinhAnhSanPhamProvider().getAll());
        }
        public ActionResult Create()
        {
            return View(new LibData.HinhAnhSanPham());
        }
        public ActionResult Edit(int id)
        {
            return View(new LibData.Provider.HinhAnhSanPhamProvider().getById(id));
        }
    }
}
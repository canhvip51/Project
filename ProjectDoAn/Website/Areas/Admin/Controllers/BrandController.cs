using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("SuperAdmin")]
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListBrand( int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.BrandProvider brandProvider = new LibData.Provider.BrandProvider();
            var list = brandProvider.GetAll(skip, size);
            var count = brandProvider.CountAll();
            StaticPagedList<LibData.Brand> pagedList = new StaticPagedList<LibData.Brand>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddBrand(int? id)
        {
            LibData.Brand brand = new LibData.Brand();
            if (id.HasValue)
            {
                brand = new LibData.Provider.BrandProvider().GetById(id.Value);
            }
            return View(brand);
        }
        [HttpPost]
        public ActionResult AddBrand(LibData.Brand model)
        {
            LibData.Provider.BrandProvider brandProvider = new LibData.Provider.BrandProvider();
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Tên hãng không được để trống");
            }
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (brandProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    if (brandProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
            }
            return View(model);
        }
    }
}
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
    public class CookieCartController : Controller
    {
        // GET: Admin/CookieCart
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListCookie(int page = 1, int size = 10)
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
        public ActionResult Detail(int id)
        {
            LibData.Cookie cookie = new LibData.Provider.CookieProvider().GetById(id);
            if (cookie != null)
                return View(cookie);
            return View(new LibData.Cookie());
        }
        public bool RemoveAll()
        {
           return new LibData.Provider.CookieProvider().RemoveAll();
        }
        public bool RemoveAllExpired()
        {
            return new LibData.Provider.CookieProvider().RemoveAllExpired();
        }
        public bool Remove(int id)
        {
            return new LibData.Provider.CookieProvider().Remove(id);
        }
    }

}

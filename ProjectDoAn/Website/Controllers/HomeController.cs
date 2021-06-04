using LibData.Configuration;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //ViewData["Sliders"] = new LibData.Provider.SlideProvider().getAll();
            //return View(new LibData.Provider.SanPhamProvider().getAllBySize(8));
            return View(new LibData.Provider.SlideProvider().GetAll());
        }
        public ActionResult ListProduct(string type)
        {
            ViewBag.Type = type;
            if (type == ViewConfig.TOPSALE)
            {
                var list = new LibData.Provider.ViewProvider().GetAllTopSale(0, 4);
                if (list.Count() > 0)
                    return View(list);
                return View(new LibData.Provider.ViewProvider().GetAllProductNew(0, 4));
            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                return View(new LibData.Provider.ViewProvider().GetAllProductNew(0, 4));
            }
            if (type == ViewConfig.DISCOUNT)
            {
                var list = new LibData.Provider.ViewProvider().GetAllProductDiscount(0, 4);
                return View(list);
            }
            if (type == ViewConfig.MALE)
            {
                return View(new LibData.Provider.ViewProvider().GetAllProductMale(0, 4));
            }
            if (type == ViewConfig.FEMALE)
            {
                return View(new LibData.Provider.ViewProvider().GetAllProductFemale(0, 4));
            }
            return View();
        }
        public ActionResult ListSlide()
        {
            return View(new LibData.Provider.SlideProvider().GetAllByStatus((int)LibData.Configuration.SlideConfig.Status.SHOW));
        }
        public List<LibData.Brand> ListBrand()
        {
            return new LibData.Provider.BrandProvider().GetAll();
        }
    }
}
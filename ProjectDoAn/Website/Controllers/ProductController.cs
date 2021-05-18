using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using LibData.Configuration;

namespace Website.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string type,string keysearch="",  int brandid = -1, int page = 1, int size = 1)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.Type = type;
            ViewBag.brandid = brandid;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            List<LibData.Product> list = new List<LibData.Product>();
            int count = 0;
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();
            if (type == ViewConfig.TOPSALE)
            {
                list = viewProvider.GetAllTopSale(keysearch, brandid, skip, size);
                count = viewProvider.CountAllTopSale(keysearch, brandid);
                if (list.Count() < 1)
                {
                    list = viewProvider.GetAllProductNew(keysearch, brandid, skip, size);
                    count = viewProvider.CountAllProductNew(keysearch, brandid);
                }

            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                list = viewProvider.GetAllProductNew(keysearch, brandid, skip, size);
                count = viewProvider.CountAllProductNew(keysearch, brandid);
            }
            if (type == ViewConfig.DISCOUNT)
            {
                list = viewProvider.GetAllProductDiscount(keysearch, brandid, skip, size);
                count = viewProvider.CountAllProductDiscount(keysearch, brandid);
            }
            if (type == ViewConfig.MALE)
            {
                list = viewProvider.GetAllProductMale(skip, size);
                count = viewProvider.CountAllProductMale(keysearch, brandid);
            }
            if (type == ViewConfig.FEMALE)
            {
                list = viewProvider.GetAllProductFemale(skip, size);
                count = viewProvider.CountAllProductFemale(keysearch, brandid);
            }
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
        public ActionResult ListAllProductByType(string keysearch, string type, int brandid = -1, int page = 1, int size = 12)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.Type = type;
            ViewBag.brandid = brandid;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            List<LibData.Product> list = new List<LibData.Product>();
            int count = 0;
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();
            if (type == ViewConfig.TOPSALE)
            {
                list = viewProvider.GetAllTopSale(keysearch, brandid, skip, size);
                count = viewProvider.CountAllTopSale(keysearch, brandid);
                if (list.Count() < 1)
                {
                    list = viewProvider.GetAllProductNew(keysearch, brandid,skip, size);
                    count = viewProvider.CountAllProductNew(keysearch, brandid);
                }

            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                list = viewProvider.GetAllProductNew(keysearch, brandid, skip, size);
                count = viewProvider.CountAllProductNew(keysearch, brandid);
            }
            if (type == ViewConfig.DISCOUNT)
            {
                list = viewProvider.GetAllProductDiscount(keysearch, brandid, skip, size);
                count = viewProvider.CountAllProductDiscount(keysearch, brandid);
            }
            if (type == ViewConfig.MALE)
            {
                list = viewProvider.GetAllProductMale(skip, size);
                count = viewProvider.CountAllProductMale(keysearch, brandid);
            }
            if (type == ViewConfig.FEMALE)
            {
                list = viewProvider.GetAllProductFemale(skip, size);
                count = viewProvider.CountAllProductFemale(keysearch, brandid);
            }
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
        public ActionResult ListAllProductByBrand(string keysearch, string type, int brandid, int page = 1, int size = 1)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.Type = type;
            ViewBag.brandid = brandid;
            int skip = (page - 1) * size;
            List<LibData.Product> list = new List<LibData.Product>();
            int count = 0;
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();
            if (type == ViewConfig.TOPSALE)
            {
                list = viewProvider.GetAllTopSale(keysearch ,brandid, skip, size);
                count = viewProvider.CountAllTopSale(keysearch, brandid);
                if (list.Count() < 1)
                {
                    list = viewProvider.GetAllProductNew(keysearch, brandid,skip, size);
                    count = viewProvider.CountAllProductNew(keysearch, brandid);
                }

            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                list = viewProvider.GetAllProductNew(keysearch, brandid,skip, size);
                count = viewProvider.CountAllProductNew(keysearch, brandid);
            }
            if (type == ViewConfig.DISCOUNT)
            {
                list = viewProvider.GetAllProductDiscount(keysearch, brandid,skip, size);
                count = viewProvider.CountAllProductDiscount(keysearch, brandid);
            }
            if (type == ViewConfig.MALE)
            {
                list = viewProvider.GetAllProductMale(keysearch, brandid,skip, size);
                count = viewProvider.CountAllProductMale();
            }
            if (type == ViewConfig.FEMALE)
            {
                list = viewProvider.GetAllProductFemale(keysearch, brandid,skip, size);
                count = viewProvider.CountAllProductFemale();
            }
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
        public ActionResult DetailProduct(int id)
        {
            return View();
        }
    }
}
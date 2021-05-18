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
        public ActionResult Index(string type, string keysearch = "",int typeselect=-1, int brandid = -1, int page = 1, int size = 1)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.typeselect = typeselect;
            ViewBag.Type = type;
            ViewBag.brandid = brandid;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            List<LibData.Product> list = new List<LibData.Product>();
            int count = 0;
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();
            if (type == ViewConfig.TOPSALE)
            {
                list = viewProvider.GetAllTopSale(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllTopSale(keysearch, typeselect, brandid);
                if (list.Count() < 1)
                {
                    list = viewProvider.GetAllProductNew(keysearch, typeselect, brandid, skip, size);
                    count = viewProvider.CountAllProductNew(keysearch, typeselect, brandid);
                }

            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                list = viewProvider.GetAllProductNew(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllProductNew(keysearch, typeselect, brandid);
            }
            if (type == ViewConfig.DISCOUNT)
            {
                list = viewProvider.GetAllProductDiscount(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllProductDiscount(keysearch, typeselect, brandid);
            }
            if (type == ViewConfig.MALE)
            {
                list = viewProvider.GetAllProductMale(keysearch, -1, brandid,skip, size);
                count = viewProvider.CountAllProductMale(keysearch,-1, brandid);
            }
            if (type == ViewConfig.FEMALE)
            {
                list = viewProvider.GetAllProductFemale(keysearch, -1, brandid,skip, size);
                count = viewProvider.CountAllProductFemale(keysearch,-1, brandid);
            }
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
        public ActionResult ListAllProductByType(string keysearch, string type, int brandid = -1, int typeselect = -1, int page = 1, int size = 12)
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
                list = viewProvider.GetAllTopSale(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllTopSale(keysearch, typeselect, brandid);
                if (list.Count() < 1)
                {
                    list = viewProvider.GetAllProductNew(keysearch, typeselect, brandid, skip, size);
                    count = viewProvider.CountAllProductNew(keysearch, typeselect, brandid);
                }

            }
            if (type == ViewConfig.PRODUCTNEW)
            {
                list = viewProvider.GetAllProductNew(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllProductNew(keysearch, typeselect, brandid);
            }
            if (type == ViewConfig.DISCOUNT)
            {
                list = viewProvider.GetAllProductDiscount(keysearch, typeselect, brandid, skip, size);
                count = viewProvider.CountAllProductDiscount(keysearch, typeselect, brandid);
            }
            if (type == ViewConfig.MALE)
            {
                list = viewProvider.GetAllProductMale(keysearch, -1, brandid, skip, size);
                count = viewProvider.CountAllProductMale(keysearch, -1, brandid);
            }
            if (type == ViewConfig.FEMALE)
            {
                list = viewProvider.GetAllProductFemale(keysearch, -1, brandid, skip, size);
                count = viewProvider.CountAllProductFemale(keysearch, -1, brandid);
            }
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
        public ActionResult ListAllProductByBrand(string keysearch,  int brandid, int typeselect = -1, int page = 1, int size = 1)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.brandid = brandid;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            List<LibData.Product> list = new List<LibData.Product>();
            int count = 0;
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();

            list = viewProvider.GetAllProductByBrand(keysearch, typeselect, brandid, skip, size);
            count = viewProvider.CountAllProductByBrand(keysearch, typeselect, brandid);
            StaticPagedList<LibData.Product> pagedlist = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedlist);
        }
    }
}
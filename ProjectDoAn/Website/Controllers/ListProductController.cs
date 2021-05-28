using LibData.Configuration;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ListProductController : Controller
    {
        // GET: ListProduct
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListAllProductByType(string type, string keysearch = "", int brandid = -1, int typeselect = -1, int page = 1, int size = 1)
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
        public ActionResult ListAllProductByBrand(int brandid, string keysearch = "", int typeselect = -1, int page = 1, int size = 1)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.typeselect = typeselect;
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
        public ActionResult DetailProduct(int id)
        {

            LibData.Product product = new LibData.Provider.ProductProvider().GetById(id);
            return View(product);
        }
        public ActionResult SelectSize(int id)
        {
            List<LibData.Warehouse> list = new LibData.Provider.WarehouseProvider().GetAllByKey(id);
            return View(list);
        }
        public ActionResult ListAllProductSimilar(int brandid, int type)
        {
            ViewBag.brandid = brandid;
            ViewBag.type = type;
            List<LibData.Product> list = new List<LibData.Product>();
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();

            list = viewProvider.GetAllProductSimilar(brandid, type, 0, 4);

            return View(list);
        }

        public bool OrderProduct(int id)
        {
            string key;
            LibData.Provider.CartProvider cartProvider = new LibData.Provider.CartProvider();
            LibData.Provider.CookieProvider cookieProvider = new LibData.Provider.CookieProvider();
            LibData.Cookie cookie = new LibData.Cookie();
            double timeout = Convert.ToDouble(new LibData.Provider.ConfigProvider().GetTimeOut_Hours_Cookie());
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            if (httpCookie == null)
            {
                httpCookie = new HttpCookie("key");
                httpCookie["keycode"] = Guid.NewGuid().ToString();
                httpCookie.Expires = DateTime.Now.AddHours(timeout);
                HttpContext.Response.Cookies.Add(httpCookie);
            }
            key = httpCookie["keycode"];
            cookie = cookieProvider.GetByKey(key);
            if (cookie == null)
            {
                httpCookie = new HttpCookie("key");
                httpCookie["keycode"] = Guid.NewGuid().ToString();
                httpCookie.Expires = DateTime.Now.AddHours(timeout);
                HttpContext.Response.Cookies.Add(httpCookie);
                cookie = new LibData.Cookie()
                {
                    KeyCode = httpCookie["keycode"],
                    ExpiredDate = DateTime.Now.AddHours(timeout),
                };
                LibData.Cart newCart = new LibData.Cart()
                {
                    WarehouseId = id,
                    Amount = 1,
                    CookieId = cookie.Id,
                    Status = 1,
                };
                cookie.Carts.Add(newCart);
                if (cookieProvider.Insert(cookie))

                    return true;
                return false;
            }
            else
            {
                httpCookie.Expires = DateTime.Now.AddHours(timeout);
                HttpContext.Response.Cookies.Add(httpCookie);
                cookie.ExpiredDate = DateTime.Now.AddHours(timeout);
                LibData.Cart cart = cookie.Carts.FirstOrDefault(x => x.WarehouseId == id );
                 if (cart == null)
                {
                    cart = new LibData.Cart();
                    cart.CreateDate = DateTime.Now;
                    cart.Status = 1;
                    cart.Amount = 1;
                    cart.CookieId = cookie.Id;
                    cart.WarehouseId = id;
                    cookie.Carts.Add(cart);
                }
                else
                {
                    cart.Amount += 1;
                    cart.UpdateDate = DateTime.Now;
                }
                if (cookieProvider.Update(cookie))
                {
                    return true;
                }
                return false;

            }
            return false;
        }
    }
}
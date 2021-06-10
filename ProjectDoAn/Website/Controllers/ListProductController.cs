using LibData.Configuration;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibData.Configuration;
using System.Net;

namespace Website.Controllers
{
    public class ListProductController : Controller
    {
        // GET: ListProduct
        public ActionResult Index(int page =1 , int size = 12 , string key="", int sex=-1, int brand=-1,string sort = "",int sizeP=-1)
        {
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.sizeP = sizeP;
            ViewBag.key = key;
            ViewBag.sex = sex;
            ViewBag.brand = brand;
            ViewBag.sort = sort;
            ViewBag.ListBrand = new LibData.Provider.BrandProvider().GetAll();
            if (string.IsNullOrEmpty(sort))
            {
                sort = ViewConfig.ALL;
            }
            int skip = (page - 1) * size;
            List<LibData.Product> list = viewProvider.GetAllByAllKey(key, brand, sex, sort,sizeP, skip, size);
            int count = viewProvider.CountAllByAllKey(key, brand, sex, sort, sizeP);
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
        public ActionResult SelectSizeSearch(int sex,int selected=-1)
        {
            ViewBag.selected = selected;
            List<LibData.Size> list = new LibData.Provider.SizeProvider().GetAllBySex(sex);
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
                    Status = CartConfig.INCART,
                    CreateDate=DateTime.Now,
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
                LibData.Cart cart = cookie.Carts.FirstOrDefault(x => x.WarehouseId == id && x.Status==1  );
                 if (cart == null)
                {
                    cart = new LibData.Cart();
                    cart.CreateDate = DateTime.Now;
                    cart.Status = CartConfig.INCART;
                    cart.Amount = 1;
                    cart.CookieId = cookie.Id;
                    cart.WarehouseId = id;
                    cookie.Carts.Add(cart);
                }
                //else
                //{
                //    cart.Amount += 1;
                //    cart.UpdateDate = DateTime.Now;
                //}
                if (cookieProvider.Update(cookie))
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return true;
                }
                return false;
            }
            return false;
        }
     
    }
}
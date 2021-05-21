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
        public ActionResult Index(string type, string keysearch = "", int typeselect = -1, int brandid = -1, int page = 1, int size = 1)
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
        public ActionResult OrderofCustomer()
        {
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            Business.CookieOrder cookieOrder = new Business.OrderList().GetCookieOrder();
            Models.CustomerOrderModel listOrderModel = new Models.CustomerOrderModel();
            if (cookieOrder != null)
            {
                for (int i = 0; i < cookieOrder.list.Count; i++)
                {
                    LibData.Warehouse warehouse = warehouseProvider.GetById(cookieOrder.list[i]);
                    listOrderModel.WarehouseId.Add(cookieOrder.list[i]);
                    if (warehouse.Amount.Value > cookieOrder.amount[i])
                        listOrderModel.Amount.Add(cookieOrder.amount[i]);
                    else
                        listOrderModel.Amount.Add(warehouse.Amount.Value);
                    listOrderModel.MaxAmount.Add(warehouse.Amount.Value);
                    listOrderModel.Avatar.Add(warehouse.ProductImg.Url);
                    listOrderModel.ProductName.Add(warehouse.ProductImg.Product.Name + " - " + warehouse.ProductImg.Color);
                    listOrderModel.Size.Add(warehouse.ProductImg.Product.Name + " - " + warehouse.ProductImg.Color);
                    listOrderModel.Price.Add(warehouse.ProductImg.Product.Price.Value * (100 - warehouse.ProductImg.Product.Discount.Value) / 100);
                }
                return View(listOrderModel);

            }
            return View(warehouseProvider);
        }
        public ActionResult CartCustomer(int brandid, int type)
        {
            ViewBag.brandid = brandid;
            ViewBag.type = type;
            List<LibData.Product> list = new List<LibData.Product>();
            LibData.Provider.ViewProvider viewProvider = new LibData.Provider.ViewProvider();

            list = viewProvider.GetAllProductSimilar(brandid, type, 0, 4);

            return View(list);
        }
        public void Order(int id)
        {
            if(new LibData.Provider.WarehouseProvider().GetById(id)!=null)
            new Business.OrderList().CustomerOrder(id);
        }
    }
}
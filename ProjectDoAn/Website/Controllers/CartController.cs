using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            LibData.Cookie cookie = new LibData.Cookie();
            if (httpCookie != null)
            {
                cookie = new LibData.Provider.CookieProvider().GetByKey(httpCookie["keycode"]);
            }
            return View(cookie);
        }
        [HttpPost]
        public ActionResult Index(LibData.Cookie model)
        {
            LibData.Provider.CookieProvider cookieProvider = new LibData.Provider.CookieProvider();
            LibData.Provider.CartProvider cartProvider = new LibData.Provider.CartProvider();
            double timeout = Convert.ToDouble(new LibData.Provider.ConfigProvider().GetTimeOut_Hours_Cookie());
            //update cookie
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            httpCookie.Expires = DateTime.Now.AddHours(timeout);
            HttpContext.Response.Cookies.Add(httpCookie);
            //change db
            var old = cookieProvider.GetById(model.Id);
            old.ExpiredDate = DateTime.Now.AddHours(timeout);
            int i = 0;
            List<LibData.Cart> carts = model.Carts.ToList();
            foreach (var item in old.Carts)
            {
                if (item.Warehouse.Amount - cartProvider.GetAmount(item.WarehouseId.Value) + item.Amount >= carts[i].Amount)
                {
                    item.Amount = carts[i].Amount;
                    item.UpdateDate = DateTime.Now;
                }
                else
                {
                    ModelState.AddModelError("error", @item.Warehouse.ProductImg.Product.Name.ToString() + " - " + @item.Warehouse.ProductImg.Color.ToString() + " VN : " + @item.Warehouse.Size.VN.ToString() + " - US : " + @item.Warehouse.Size.US.ToString() + " - UK : " + @item.Warehouse.Size.UK.ToString() + " không đủ số lượng. ");
                    ModelState.AddModelError("error", @item.Warehouse.ProductImg.Product.Name.ToString() + " - " + @item.Warehouse.ProductImg.Color.ToString() + " VN : " + @item.Warehouse.Size.VN.ToString() + " - US : " + @item.Warehouse.Size.US.ToString() + " - UK : " + @item.Warehouse.Size.UK.ToString() + " không đủ số lượng. ");
                }
                i++;
                if (i > carts.Count)
                    break;
            }
            if (ModelState.IsValid)
            {
                if (cookieProvider.Update(old))
                {
                    ModelState.AddModelError("success", "Cập nhật gió hàng thành công.");
                }
                else
                {
                    ModelState.AddModelError("error", "Cập nhật gió hàng thất bại.");
                }
            }
            return View(old);
        }
        [HttpGet]
        public ActionResult Order()
        {
            int total = 0;
            LibData.Provider.CartProvider cartProvider = new LibData.Provider.CartProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();
            if (httpCookie != null)
            {
                List<LibData.Cart> listCart = cartProvider.GetAllByKey(httpCookie["keycode"]);
                if (listCart != null)
                {
                    foreach (var item in listCart)
                    {
                        LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                        {
                            Amount = item.Amount,
                            WarehouseId = item.WarehouseId,
                            Price = item.Warehouse.ProductImg.Product.Price * (100 - item.Warehouse.ProductImg.Product.Discount) / 100,
                        };
                        total += orderDetail.Price.Value;
                        listOrderDetail.Add(orderDetail);
                    }
                }
            }
            LibData.Order order = new LibData.Order();
            order.Total = total;
            order.OrderDetails = listOrderDetail;
            return View(order);
        }
        [HttpPost]
        public ActionResult Order(LibData.Order model)
        {
            int total = 0;
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            LibData.Provider.CartProvider cartProvider = new LibData.Provider.CartProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            List<LibData.Cart> listCart = new List<LibData.Cart>();
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();
            Random r = new Random();
            int k = r.Next(1000, 9999);
            if (httpCookie != null)
            {
                listCart = cartProvider.GetAllByKey(httpCookie["keycode"]);
                if (listCart != null)
                {
                    foreach (var item in listCart)
                    {
                        LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                        {
                            Amount = item.Amount,
                            WarehouseId = item.WarehouseId,
                            Price = item.Warehouse.ProductImg.Product.Price * (100 - item.Warehouse.ProductImg.Product.Discount) / 100,
                        };
                        total += orderDetail.Price.Value;
                        listOrderDetail.Add(orderDetail);
                    }
                }
            }
            model.Code = "SHOESSHOP"  + DateTime.Now.ToString("yyyyMMddHHmmss") + k;
            model.CreateDate = DateTime.Now;
            model.Status = 1;
            model.Total = total;
            model.OrderDetails = listOrderDetail;
            listCart.ForEach(x => x.Status = 2);
            listCart.ForEach(x => x.UpdateDate = DateTime.Now);
            listCart.ForEach(x => x.Warehouse.Amount = x.Warehouse.Amount-x.Amount);
            if (orderProvider.Insert(model))
                {
                    ModelState.AddModelError("success", "Đặt hàng thành công.");
                    httpCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(httpCookie);
                    return View(new LibData.Order());
                }
                else
                {
                    model.Total = total;
                    model.OrderDetails = listOrderDetail;
                    ModelState.AddModelError("error", "Đặt hàng thất bại.");
                    return View(model);
                }

        }
    }
}
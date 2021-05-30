using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibData.Configuration;

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
            foreach (var item in old.Carts.Where(x=>x.Status==1&&(x.IsDelete==0||x.IsDelete==null)))
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
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            int total = 0;
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            LibData.Provider.CookieProvider cookieProvider = new LibData.Provider.CookieProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            LibData.Cookie cookies = new LibData.Cookie();
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();

            if (httpCookie != null)
            {
                cookies = cookieProvider.GetByKey(httpCookie["keycode"]);
                if (cookies != null)
                {
                    foreach (var item in cookies.Carts.Where(x => x.Status == 1 && x.IsDelete == 0 || x.IsDelete == null))
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
            if (string.IsNullOrEmpty(model.BuyerName))
            {
                ModelState.AddModelError("BuyerName", "Xin mời nhập họ tên.");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Xin mời nhập số điện thoại nhận hàng.");
            }
            if (string.IsNullOrEmpty(model.AddressTo))
            {
                ModelState.AddModelError("AddressTo", "Xin mời nhập số địa chỉ nhận hàng.");
            }
            if (model.ProvinceId == -1)
            {
                ModelState.AddModelError("ProvinceId", "Xin mời chọn thành phố bạn đang sống");
            }

            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            int total = 0;
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            LibData.Provider.CookieProvider cookieProvider = new LibData.Provider.CookieProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            LibData.Cookie cookies = new LibData.Cookie();
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();

            if (httpCookie != null)
            {
                cookies = cookieProvider.GetByKey(httpCookie["keycode"]);
                if (cookies != null)
                {
                    foreach (var item in cookies.Carts.Where(x=>x.Status==1 && x.IsDelete==0 || x.IsDelete==null))
                    {
                        LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                        {
                            Amount = item.Amount,
                            WarehouseId=item.WarehouseId,
                            Price = item.Warehouse.ProductImg.Product.Price * (100 - item.Warehouse.ProductImg.Product.Discount) / 100,
                        };
                        total += orderDetail.Price.Value;
                        listOrderDetail.Add(orderDetail);
                    }
                }
            }
            
            model.Total = total;
            model.OrderDetails = listOrderDetail;
           
            if (ModelState.IsValid)
            {
                Random r = new Random();
                int k = r.Next(1000, 9999);
                model.Code = "SHOESSHOP" + DateTime.Now.ToString("yyyyMMddHHmmss") + k;
                model.CreateDate = DateTime.Now;
                model.Status = 1;
                cookies.Carts.Where(x => x.Status == 1 && x.IsDelete == 0 || x.IsDelete == null).ToList().ForEach(x => x.Status = CartConfig.ORDERED);
                cookies.Carts.Where(x => x.Status == 1 && x.IsDelete == 0 || x.IsDelete == null).ToList().ForEach(x => x.UpdateDate = DateTime.Now);
                cookies.Carts.Where(x => x.Status == 1 && x.IsDelete == 0 || x.IsDelete == null).ToList().ForEach(x => x.Warehouse.UpdateDate = DateTime.Now);
                cookies.Carts.Where(x => x.Status == 1 && x.IsDelete == 0 || x.IsDelete == null).ToList().ForEach(x => x.Warehouse.Amount = x.Warehouse.Amount - x.Amount);
                if (orderProvider.Insert(model))
                {
                    cookieProvider.Update(cookies);
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
            return View(model);
        }
        public bool RemoveProductFromCart(int id)
        {
            LibData.Provider.CartProvider cartProvider = new LibData.Provider.CartProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            if (httpCookie == null)
            {
                return false;
            }
            LibData.Cart old = cartProvider.GetByProductAndKey(id, httpCookie["keycode"]);
            if (old != null)
            {
                old.Status = CartConfig.CANCEL;
                old.IsDelete = CartConfig.ISDELETE;
                old.UpdateDate = DateTime.Now;
                if (cartProvider.Update(old))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
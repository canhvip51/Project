using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibData.Configuration;
using PagedList;

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
            foreach (var item in old.Carts.Where(x=>x.Status==1))
            {
                if (item.Warehouse.Amount - cartProvider.GetAmount(item.WarehouseId.Value) + item.Amount >= carts[i].Amount)
                {
                    item.Amount = carts[i].Amount;
                    item.UpdateDate = DateTime.Now;
                }
                else
                {
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
                    foreach (var item in cookies.Carts.Where(x => x.Status == 1))
                    {
                        LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                        {
                            Amount = item.Amount,
                            WarehouseId = item.WarehouseId,
                            Price = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(item.Warehouse.ProductImg.Product.Price.Value / 1000 * (100 - item.Warehouse.ProductImg.Product.Discount.Value) / 100)) * 1000),
                        };
                        listOrderDetail.Add(orderDetail);
                    }
                }
            }
            LibData.Order order = new LibData.Order();
            order.Discount = 0;
            order.OrderDetails = listOrderDetail;
            return View(order);
        }
        [HttpPost]
        public ActionResult Order(LibData.Order model)
        {
            LibData.Provider.PromotionProvider promotionProvider = new LibData.Provider.PromotionProvider();
            LibData.Promotion promotion = null;
            if (string.IsNullOrEmpty(model.BuyerName))
            {
                ModelState.AddModelError("BuyerName", "Xin mời nhập họ tên.");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Xin mời nhập số điện thoại nhận hàng.");
            }
            if (model.Phone.Length!=10)
            {
                ModelState.AddModelError("Phone", "Số điện thoại không khả dụng.");
            }
            if (!ViewConfig.ListPay.Contains(model.Type.Value))
            {
                ModelState.AddModelError("Type", "Vui lòng chọn hình thức thanh toán.");
            }
            if (string.IsNullOrEmpty(model.AddressTo))
            {
                ModelState.AddModelError("AddressTo", "Xin mời nhập số địa chỉ nhận hàng.");
            }
            if (model.ProvinceId == -1)
            {
                ModelState.AddModelError("ProvinceId", "Xin mời chọn thành phố bạn đang sống.");
            }
            if (!string.IsNullOrEmpty(model.KeyCode))
            {
                 promotion = promotionProvider.GetByKeyCode(model.KeyCode);
                if (promotion == null)
                {
                    model.Discount = 0;
                    model.KeyCode = "";
                    ModelState.AddModelError("KeyCode", "Mã giảm giá không tồn tại hoặc đã hết.");
                }
                else
                {
                    if (promotion.Amount.HasValue)
                        promotion.Amount -= 1;
                    model.Discount = promotion.Discount.Value;
                }
            }
            else
            {
                model.Discount = 0;
            }
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            LibData.Provider.CookieProvider cookieProvider = new LibData.Provider.CookieProvider();
            HttpCookie httpCookie = HttpContext.Request.Cookies["key"];
            LibData.Cookie cookies = new LibData.Cookie();
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();

           
           
            if (ModelState.IsValid)
            {

                if (httpCookie != null)
                {
                    cookies = cookieProvider.GetByKey(httpCookie["keycode"]);
                    if (cookies != null)
                    {
                        foreach (var item in cookies.Carts.Where(x => x.Status == 1))
                        {
                            LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                            {
                                Amount = item.Amount,
                                WarehouseId = item.WarehouseId,
                                Price = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(item.Warehouse.ProductImg.Product.Price.Value / 1000 * (100 - item.Warehouse.ProductImg.Product.Discount.Value) / 100)) * 1000),
                            };
                            listOrderDetail.Add(orderDetail);
                        }
                    }
                }
                model.OrderDetails = listOrderDetail;
                model.Total =Convert.ToInt32(Math.Ceiling(Convert.ToDouble(model.OrderDetails.Sum(x => x.Price.Value * x.Amount.Value) / 1000 * (100 - model.Discount.Value) / 100)))*1000;
                Random r = new Random();
                int k = r.Next(1000, 9999);
                model.Code = "SHOESSHOP" + DateTime.Now.ToString("yyyyMMddHHmmss") + k;
                model.CreateDate = DateTime.Now;
                model.Status = 1;
                model.Discount=model.Discount??0;
                model.CustomerPay=0;
                cookies.Carts.Where(x => x.Status == 1).ToList().ForEach(x => x.Status = CartConfig.ORDERED);
                cookies.Carts.Where(x => x.Status == 1).ToList().ForEach(x => x.UpdateDate = DateTime.Now);
                if (orderProvider.Insert(model))
                {
                    promotionProvider.Update();
                    cookieProvider.Remove(cookies);
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    ModelState.AddModelError("success", "Đặt hàng thành công.");
                    httpCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(httpCookie);
                    return View(new LibData.Order());
                }
                else
                {
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
                if (cartProvider.Remove(old))
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPost]
        public ActionResult ApplyPromotion(LibData.Order model)
        {
            if (string.IsNullOrEmpty(model.BuyerName))
            {
                ModelState.AddModelError("BuyerName", "Xin mời nhập họ tên.");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Xin mời nhập số điện thoại nhận hàng.");
            }
            if (model.Phone.Length != 10)
            {
                ModelState.AddModelError("Phone", "Số điện thoại không khả dụng.");
            }
            if (string.IsNullOrEmpty(model.AddressTo))
            {
                ModelState.AddModelError("AddressTo", "Xin mời nhập số địa chỉ nhận hàng.");
            }
            if (model.ProvinceId == -1)
            {
                ModelState.AddModelError("ProvinceId", "Xin mời chọn thành phố bạn đang sống.");
            }
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
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
                    foreach (var item in cookies.Carts.Where(x => x.Status == 1))
                    {
                        LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                        {
                            Amount = item.Amount,
                            WarehouseId = item.WarehouseId,
                            Price = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(item.Warehouse.ProductImg.Product.Price.Value/1000 * ((100 - item.Warehouse.ProductImg.Product.Discount.Value) / 100)))*1000),
                        };
                        listOrderDetail.Add(orderDetail);
                    }
                }
            }
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.KeyCode))
                {
                    LibData.Promotion promotion = new LibData.Provider.PromotionProvider().GetByKeyCode(model.KeyCode);
                    if (promotion == null)
                    {
                        model.Discount = 0;
                        model.KeyCode = "";
                        ModelState.AddModelError("KeyCode", "Mã giảm giá không tồn tại hoặc đã hết.");
                    }
                    else
                    {
                        if (orderProvider.CheckPhoneUserKey(model.Phone, model.KeyCode))
                        {
                            ModelState.AddModelError("KeyCode", "Mã giảm giá đã sử dụng.");
                        }
                        else
                        model.Discount = promotion.Discount.Value;
                    }
                }
            }
            model.OrderDetails = listOrderDetail;
            return View("Order", model);
        }
        public ActionResult OrderList(string phone,int page=1 , int size=5)
        {
            LibData.Provider.OrderProvider orderProvide = new LibData.Provider.OrderProvider();
            ViewBag.Phone = phone;
            ViewBag.Page = page;
            ViewBag.Size = size;
            int skip = (page - 1) * size;
            List<LibData.Order> orders = orderProvide.GetAllByPhone(phone, skip, size); 
            int count = orderProvide.CountAllByPhone(phone);
            StaticPagedList<LibData.Order> pageList = new StaticPagedList<LibData.Order>(orders, page, size, count);
                return View(pageList);
        }
    }
}
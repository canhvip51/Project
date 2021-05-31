using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Website.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string keysearch, int status =-1,int page = 1, int size = 10)
        {
            ViewBag.keysearch = keysearch;
            ViewBag.status = status;
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListOrder(string keysearch, int status = -1, int page = 1, int size = 10)
        {
            ViewBag.keysearch = keysearch;
            ViewBag.status = status;
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            var list = orderProvider.GetAllByKey(keysearch,status,skip, size);
            var count = orderProvider.CountAllByKey(keysearch, status);
            StaticPagedList<LibData.Order> pagedList = new StaticPagedList<LibData.Order>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddOrder()
        {

            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Order order = new LibData.Order();
            order.Total = 0;
            return View(order);
        }
        [HttpPost]
        public ActionResult AddOrder(LibData.Order model)
        {
            int total = 0;
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
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
            foreach (var item in model.OrderDetails)
            {
                LibData.Warehouse warehouse = new LibData.Provider.WarehouseProvider().GetById(item.WarehouseId.Value);
                int amount = 0;
                total += item.Price.Value * item.Amount.Value;
                if (warehouse.Carts != null)
                {
                    amount = warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value);
                }
                if (item.Amount.Value > warehouse.Amount.Value - amount)
                {
                    ModelState.AddModelError("error", "Sản phẩm" + warehouse.ProductImg.Product.Name.ToString() + " - " + warehouse.ProductImg.Color.ToString() + " VN : " + warehouse.Size.VN.ToString() + " - US : " + warehouse.Size.US.ToString() + " - UK : " + warehouse.Size.UK.ToString() + " chỉ còn " + (warehouse.Amount.Value - amount).ToString());
                }
            }
            model.Total = total;
            if (ModelState.IsValid)
            {

                //if (model.Id > 0)
                //{
                //    if (importUnitProvider.Update(model))
                //    {
                //        Response.StatusCode = (int)HttpStatusCode.Created;
                //        return View(model);

                //    }
                //    ModelState.AddModelError("Error", "Lỗi hệ thống");
                //}
                //else
                //{
                    if (orderProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                //}
            }
            return View(model);
        }

        public ActionResult UpdateOrder(LibData.Order model)
        {
            int total = 0;
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            foreach (var item in model.OrderDetails)
            {
                LibData.Warehouse warehouse = new LibData.Provider.WarehouseProvider().GetById(item.WarehouseId.Value);
                int amount = 0;
                total += item.Price.Value * item.Amount.Value;
                if (warehouse.Carts != null)
                {
                    amount = warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value);
                }
                if (item.Amount.Value > warehouse.Amount.Value - amount)
                {
                    ModelState.AddModelError("error","Sản phẩm" + warehouse.ProductImg.Product.Name.ToString() + " - " + warehouse.ProductImg.Color.ToString() + " VN : " + warehouse.Size.VN.ToString() + " - US : " + warehouse.Size.US.ToString() + " - UK : " + warehouse.Size.UK.ToString() + " chỉ còn "+(warehouse.Amount.Value - amount).ToString());
                }    
            }
            model.Total = total;
            return View("AddOrder",model);
        }
        [HttpGet]
        public ActionResult AddOrderDetail(string list)
        {
            if (string.IsNullOrEmpty(list))
                list = "0";
            List<string> listDatas = list.Split(',').ToList();
            ViewBag.listDatas = listDatas;
            ViewBag.Warehouse = new LibData.Provider.WarehouseProvider().GetAll().Where(x=>x.Amount>0).ToList();
            LibData.OrderDetail orderDetail = new LibData.OrderDetail();
            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult AddOrderDetail(LibData.OrderDetail model, string list )
        {
            if (string.IsNullOrEmpty(list))
                list = "0";
            List<string> listDatas = list.Split(',').ToList();
            ViewBag.listDatas = listDatas;
            ViewBag.Warehouse = new LibData.Provider.WarehouseProvider().GetAll().Where(x => x.Amount > 0).ToList();
            LibData.Warehouse warehouse = new LibData.Provider.WarehouseProvider().GetById(model.WarehouseId.Value);
            int amount = warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value);
            if (listDatas.Contains(model.WarehouseId.ToString()))
            {
                ModelState.AddModelError("WarehouseId", "Sản phẩm đã có trong giỏ hàng vui lòng thực hiện thao tác trên giỏ");
            }
            else
            {
                if (model.Amount.HasValue)
                {
                    if (model.Amount.Value > warehouse.Amount.Value - amount)
                    {
                        ModelState.AddModelError("Amount", "Số lượng trong kho không đủ");
                    }
                }
                else
                {
                    ModelState.AddModelError("Amount", "Vui lòng nhập số lượng");
                }
            }
          
          
            if (ModelState.IsValid)
            {
                model.Price = warehouse.ProductImg.Product.Price * (100 - warehouse.ProductImg.Product.Discount) / 100;
                Response.StatusCode = (int)HttpStatusCode.Created;
                return PartialView("trAddOrderDetail", model);
            }
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            return View(new LibData.Provider.OrderProvider().GetById(id));
        }
        public ActionResult ListOrderDetail(int id)
        {
            return View(new LibData.Provider.OrderProvider().GetById(id));
        }
    }
}
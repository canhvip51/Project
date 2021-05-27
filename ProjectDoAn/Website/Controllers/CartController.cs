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
                    listOrderModel.Size.Add("VN : " + warehouse.Size.VN.ToString() + "- US :" + warehouse.Size.US.ToString() + "- UK :" + warehouse.Size.UK.ToString());
                    listOrderModel.Price.Add(warehouse.ProductImg.Product.Price.Value * (100 - warehouse.ProductImg.Product.Discount.Value) / 100);
                }
                return View(listOrderModel);

            }
            return View(warehouseProvider);
        }
        [HttpPost]
        public ActionResult Index(Models.CustomerOrderModel model)
        {
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            new Business.OrderList().UpdateCart(model.WarehouseId, model.Amount);
            return View(warehouseProvider);
        }
        public ActionResult Order()
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
                    listOrderModel.Amount.Add(cookieOrder.amount[i]);
                    listOrderModel.ProductName.Add(warehouse.ProductImg.Product.Name + " - " + warehouse.ProductImg.Color);
                    listOrderModel.Size.Add("VN : " +warehouse.Size.VN.ToString() +"- US :" +warehouse.Size.US.ToString() +"- UK :"+ warehouse.Size.UK.ToString());
                    listOrderModel.Price.Add(warehouse.ProductImg.Product.Price.Value * (100 - warehouse.ProductImg.Product.Discount.Value) / 100);
                    listOrderModel.TotalPrice.Add(listOrderModel.Amount[i]*listOrderModel.Price[i]);
                }
                listOrderModel.Total = listOrderModel.TotalPrice.Sum();
                return View(listOrderModel);

            }
            return View(warehouseProvider);
        }
        [HttpPost]
        public ActionResult Order(Models.CustomerOrderModel model)
        {
            int price=0;
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            Models.CustomerOrderModel listOrderModel = new Models.CustomerOrderModel();
            List<LibData.OrderDetail> listOrderDetail = new List<LibData.OrderDetail>();
            if (model.WarehouseId != null)
            {
                for (int i = 0; i < model.WarehouseId.Count; i++)
                {
                    LibData.Warehouse warehouse = warehouseProvider.GetById(model.WarehouseId[i]);
                 if (warehouse != null)
                    {
                        if (warehouse.Amount < model.Amount[i])
                            ModelState.AddModelError("error", "Số lượng " + model.ProductName[i] + " - " + model.Size[i] + " không đủ.");
                        else
                        {
                            LibData.OrderDetail orderDetail = new LibData.OrderDetail()
                            {
                                Amount = model.Amount[i],
                                WarehouseId = model.WarehouseId[i],
                                Price = (model.Amount[i] * (warehouse.ProductImg.Product.Price.Value*(100-warehouse.ProductImg.Product.Discount)/100)),
                            };
                            price += orderDetail.Price.Value;
                            listOrderDetail.Add(orderDetail);
                        }
                         
                    }
                    else
                    {
                        ModelState.AddModelError("error", "Sản phẩm " + model.ProductName[i] + " - " + model.Size[i] + " không tồn tại.");
                    }
                    if (ModelState.IsValid)
                    {
                        LibData.Order order = new LibData.Order()
                        {
                            BuyerName = model.BuyerName,
                            Phone = model.Phone,
                            AddressFrom = model.AddressFrom,
                            Note = model.Note,
                            Total=price,
                        };
                        if(new LibData.Provider.OrderProvider().Insert(order))
                        {
                            model.Id = order.Id;
                            foreach (var item in listOrderDetail)
                            {
                                //Add orderdetail
                                item.OrderId = order.Id;
                            }
                            if(new LibData.Provider.OrderDetailProvider().InsertAll(listOrderDetail))
                            {
                                ModelState.AddModelError("success", "Đặt hàng thành công");
                                Response.StatusCode = (int)HttpStatusCode.Created;
                                return View(model);
                            }

                        }
                    }
                }
                return View(listOrderModel);

            }
            return View(warehouseProvider);
        }
    }
}
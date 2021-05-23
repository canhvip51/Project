using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart()
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
        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}
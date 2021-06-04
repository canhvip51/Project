using OfficeOpenXml;
using OfficeOpenXml.Style;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("SuperAdmin")]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string keysearch, int status = -1, int page = 1, int size = 10)
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
            var list = orderProvider.GetAllByKey(keysearch, status, skip, size);
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
            order.CustomerPay = 0;
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
                if (warehouse == null)
                {
                    total = 0;
                    ModelState.AddModelError("error", "Lỗi");
                    break;
                }
                int amount = 0;
                total += item.Price.Value * item.Amount.Value;
                if (warehouse.Carts != null)
                {
                    amount = (warehouse.Carts != null ? warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value) : 0) - (warehouse.OrderDetails != null ? warehouse.OrderDetails.Where(x => x.Order.Status == (int)LibData.Configuration.OrderConfig.Status.WAIT && (x.IsDelete == null || x.IsDelete.Value == 0) && x.WarehouseId != item.WarehouseId).ToList().Sum(x => x.Amount.Value) : 0);
                }
                if (item.Amount.Value > warehouse.Amount.Value - amount)
                {
                    total = 0;
                    ModelState.AddModelError("error", "Sản phẩm" + warehouse.ProductImg.Product.Name.ToString() + " - " + warehouse.ProductImg.Color.ToString() + " VN : " + warehouse.Size.VN.ToString() + " - US : " + warehouse.Size.US.ToString() + " - UK : " + warehouse.Size.UK.ToString() + " chỉ còn " + (warehouse.Amount.Value - amount).ToString());
                    break;
                }
                if (item.Amount.Value < 0)
                {
                    total = 0;
                    ModelState.AddModelError("error", "Số lượng sản phẩm không khả dụng");
                    break;
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
                Random r = new Random();
                int k = r.Next(1000, 9999);
                model.Code = "SHOESSHOP" + DateTime.Now.ToString("yyyyMMddHHmmss") + k;
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
                if (warehouse == null)
                {
                    ModelState.AddModelError("error", "Lỗi");
                    total = 0;
                    break;
                }
                int amount = 0;
                total += item.Price.Value * item.Amount.Value;
                if (warehouse.Carts != null)
                {
                    amount = (warehouse.Carts != null ? warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value) : 0) - (warehouse.OrderDetails != null ? warehouse.OrderDetails.Where(x => x.Order.Status == (int)LibData.Configuration.OrderConfig.Status.WAIT && (x.IsDelete == null || x.IsDelete.Value == 0) && x.WarehouseId != item.WarehouseId).ToList().Sum(x => x.Amount.Value) : 0);
                }
                if (item.Amount.Value > warehouse.Amount.Value - amount)
                {
                    total = 0;
                    ModelState.AddModelError("error", "Sản phẩm" + warehouse.ProductImg.Product.Name.ToString() + " - " + warehouse.ProductImg.Color.ToString() + " VN : " + warehouse.Size.VN.ToString() + " - US : " + warehouse.Size.US.ToString() + " - UK : " + warehouse.Size.UK.ToString() + " chỉ còn " + (warehouse.Amount.Value - amount).ToString());
                    break;
                }
                if (item.Amount.Value < 0)
                {
                    total = 0;
                    ModelState.AddModelError("error", "Số lượng sản phẩm không khả dụng");
                    break;
                }
            }
            model.Total = total;
            return View("AddOrder", model);
        }
        [HttpGet]
        public ActionResult AddOrderDetail(string list)
        {
            if (string.IsNullOrEmpty(list))
                list = "0";
            List<string> listDatas = list.Split(',').ToList();
            ViewBag.listDatas = listDatas;
            ViewBag.Warehouse = new LibData.Provider.WarehouseProvider().GetAll().Where(x => x.Amount > 0).ToList();
            LibData.OrderDetail orderDetail = new LibData.OrderDetail();
            return View(orderDetail);
        }
        [HttpPost]
        public ActionResult AddOrderDetail(LibData.OrderDetail model, string list)
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
                        ModelState.AddModelError("Amount", "Sản phẩm chỉ còn " + (warehouse.Amount.Value - amount).ToString() + " trong kho.");
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
        [HttpGet]
        public ActionResult Detail(int id)
        {
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            return View(new LibData.Provider.OrderProvider().GetById(id));
        }
        [HttpPost]
        public ActionResult Detail(LibData.Order model)
        {
            int total = 0;
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Provider.OrderProvider orderProvider = new LibData.Provider.OrderProvider();
            LibData.Order order = orderProvider.GetById(model.Id);
            if (order.Status == (int)LibData.Configuration.OrderConfig.Status.CANCEL)
            {
                return View(order);
            } 
                if (!LibData.Configuration.OrderConfig.StatusToDictionaryHTML.ContainsKey(model.Status.Value))
            {
                ModelState.AddModelError("error", "Lỗi");
                return View(order);
            }
            if (order.Status != (int)LibData.Configuration.OrderConfig.Status.FINISH && model.Status == (int)LibData.Configuration.OrderConfig.Status.CONFIRM)
            {
                ModelState.AddModelError("error", "Lỗi");
                return View(order);
            }
            if (order.Status != (int)LibData.Configuration.OrderConfig.Status.WAIT && model.Status == (int)LibData.Configuration.OrderConfig.Status.WAIT)
            {
                ModelState.AddModelError("error", "Lỗi");
                return View(order);
            }
            if (order.Status == (int)LibData.Configuration.OrderConfig.Status.WAIT)
            {
                foreach (var item in model.OrderDetails)
                {
                    if (item.Amount < 1)
                    {
                        ModelState.AddModelError("error", "Lỗi");
                        break;
                    }
                    int amount = 0;
                    {
                        LibData.Warehouse warehouse = new LibData.Provider.WarehouseProvider().GetById(item.WarehouseId.Value);
                        if (warehouse == null)
                        {
                            ModelState.AddModelError("error", "Lỗi");
                            break;
                        }
                        amount = (warehouse.Carts != null ? warehouse.Carts.Where(x => x.Cookie.ExpiredDate > DateTime.Now && (x.IsDelete == null || x.IsDelete.Value == 0) && x.Status.Value == 1).ToList().Sum(x => x.Amount.Value) : 0) - (warehouse.OrderDetails != null ? warehouse.OrderDetails.Where(x => x.Order.Status == (int)LibData.Configuration.OrderConfig.Status.WAIT && (x.IsDelete == null || x.IsDelete.Value == 0) && x.WarehouseId != item.WarehouseId).ToList().Sum(x => x.Amount.Value) : 0);
                        if (item.Amount.Value > warehouse.Amount.Value - amount)
                        {
                            ModelState.AddModelError("error", "Sản phẩm" + item.Warehouse.ProductImg.Product.Name.ToString() + " - " + item.Warehouse.ProductImg.Color.ToString() + " VN : " + item.Warehouse.Size.VN.ToString() + " - US : " + item.Warehouse.Size.US.ToString() + " - UK : " + item.Warehouse.Size.UK.ToString() + " chỉ còn " + (item.Warehouse.Amount.Value - amount).ToString());
                            break;
                        }
                        order.OrderDetails.First(x => x.WarehouseId == item.WarehouseId).Amount = item.Amount.Value;
                        total += item.Amount.Value * order.OrderDetails.First(x => x.WarehouseId == item.WarehouseId).Price.Value;
                    }
                }
                order.Total = total;
            }
            if (ModelState.IsValid)
            {
                order.Refuse = model.Refuse;
                order.UpdateDate = DateTime.Now;
                if (orderProvider.Update(order))
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                }
            }
            return View(order);
        }
        public bool RemoveProductInOrder(int id)
        {
            return true;
        }
        public ActionResult ListOrderDetail(int id)
        {
            return View(new LibData.Provider.OrderProvider().GetById(id));
        }
        public FileResult Export()
        {
            FileInfo file = new FileInfo(Server.MapPath(@"/Template/ListOrder.xlsx"));
            ExcelPackage package = new ExcelPackage(file);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorkbook workbook = package.Workbook;


            ExcelWorksheet sheet = workbook.Worksheets[0];
            int stt = 1;
            int startrow = 2;
            List<LibData.Order> orders = new LibData.Provider.OrderProvider().GetAll();
            foreach (var item in orders)
            {
                sheet.Cells[startrow, 1].Value = stt;
                sheet.Cells[startrow, 2].Value = item.Code;
                sheet.Cells[startrow, 3].Value = item.Phone;
                sheet.Cells[startrow, 4].Value = item.BuyerName;
                sheet.Cells[startrow, 5].Value = item.AddressTo;
                sheet.Cells[startrow, 6].Value = LibData.Configuration.OrderConfig.StatusToDictionaryHTML[item.Status.Value];
                sheet.Cells[startrow, 7].Value = item.Total;
                startrow++;
                stt++;
            }
            var modelTable = sheet.Cells["A2:G" + (startrow - 1)];
            modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            modelTable.AutoFitColumns();
            string filename = "BaoCao_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
        }
        //public FileResult Export(string keysearch="",int status=-1)
        //{
        //    return File();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("Admin", "Manager")]
    public class ImportDetailController : Controller
    {
        // GET: Admin/ImportDetail
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddImportDetail()
        {
            ViewBag.ProductImg = new LibData.Provider.ProductImgProvider().GetAll();

            return View(new LibData.ImportDetail() { Amount = 0,Price=0,Warehouse=new LibData.Warehouse() }); ;
        }
        [HttpPost]
        public ActionResult AddImportDetail(LibData.ImportDetail model,string list)
        {
            if (string.IsNullOrEmpty(list))
                list = "0";
            List<string> listDatas = list.Split(',').ToList();
            ViewBag.ProductImg = new LibData.Provider.ProductImgProvider().GetAll();
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            if(!(new LibData.Provider.ProductImgProvider().GetAll().Select(x=>x.Id).Contains(model.Warehouse.ProductImgId.Value)) || !(new LibData.Provider.SizeProvider().GetAll().Select(x => x.Id).Contains(model.Warehouse.SizeId.Value)))
            {
                ModelState.AddModelError("error","Lỗi hệ thống");
            }
            if(!warehouseProvider.CheckSize(model.Warehouse))
            {
                
                warehouseProvider.Insert(model.Warehouse);
            }
            else
            {
                model.Warehouse = warehouseProvider.GetBySize(model.Warehouse.ProductImgId.Value, model.Warehouse.SizeId.Value);
            }
            if (model.Amount < 1)
            {
                ModelState.AddModelError("Amount", "Số lượng không khả dung.");
            }
            if (model.Price < 10000)
            {
                ModelState.AddModelError("Price", "Giá không khả dụng.");
            }
            if (ModelState.IsValid)
            {
                if (list.Contains(model.Warehouse.SizeId.ToString()))
                {
                    ModelState.AddModelError("error", "Sản phẩm đã có trong phiếu nhập.");
                    return View(model);
                }
                model.WarehouseId = model.Warehouse.Id;
                Response.StatusCode = (int)HttpStatusCode.Created;
                return PartialView("trAddImportDetail", model);
            }
            return View(model);
        }
    }
}
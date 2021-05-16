using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListWarehouse(int productImgid,int page = 1, int size = 9)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.productImgid = productImgid;
            int skip = (page - 1) * size;
            LibData.Provider.WarehouseProvider warehouseProvider= new LibData.Provider.WarehouseProvider();
            var list = warehouseProvider.GetAllByKey(productImgid, skip, size);
            var count = warehouseProvider.CountAllBykey(productImgid);
            StaticPagedList<LibData.Warehouse> pagedList = new StaticPagedList<LibData.Warehouse>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddWarehouse(int? id,int productImgid)
        {
            ViewBag.ProductImg = new LibData.Provider.ProductImgProvider().GetById(productImgid);
            LibData.Warehouse warehouse = new LibData.Warehouse();
            warehouse.ProductImgId = productImgid;
            warehouse.Discount = 0;
            if (id.HasValue)
            {
                warehouse = new LibData.Provider.WarehouseProvider().GetById(id.Value);
            }
            return View(warehouse);
        }
        [HttpPost]
        public ActionResult AddWarehouse(LibData.Warehouse model)
        {
            ViewBag.ProductImg = new LibData.Provider.ProductImgProvider().GetById(model.ProductImgId.Value);
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Tên hãng không được để trống");
            if (model.Discount<0&& model.Discount>99)
            {
                ModelState.AddModelError("Discount", "Giảm giá không khả dụng");
            }
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (warehouseProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    model.Status = 1;
                    model.Amount = 0;
                    if (warehouseProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
            }
            return View(model);
        }
    }
}
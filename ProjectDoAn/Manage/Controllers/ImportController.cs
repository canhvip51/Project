using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        // GET: ImportUnit
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListImport(int warehouseid = -1, int importunitid = -1, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.warehouseid = warehouseid;
            ViewBag.importunitid = importunitid;
            int skip = (page - 1) * size;
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
            var list = importProvider.GetAllByKey(warehouseid, importunitid, skip, size);
            var count = importProvider.CountAllByKey(warehouseid, importunitid);
            StaticPagedList<LibData.Import> pagedList = new StaticPagedList<LibData.Import>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddImport(int? id, int? warehouseid, int? importunitid, int productid = -1, int productimgid = -1)
        {
            LibData.Provider.ProductImgProvider productImgProvider = new LibData.Provider.ProductImgProvider(); 
            var size = new List<LibData.Size>();
            var productimg = productImgProvider.GetById(productimgid);
            var warehouse = new LibData.Provider.WarehouseProvider().GetById(warehouseid.HasValue? warehouseid.Value:-1);
            if (productimgid!=-1)
            {
                size = new LibData.Provider.SizeProvider().GetAllBySex(productimg.Product.Type.Value);
            }
            ViewBag.productimgid = productimgid;
            productid = (int)(warehouse != null ? warehouse.ProductImg.ProductId : (productimg != null ? productimg.ProductId : productid));
            ViewBag.Size = size;
            ViewBag.ProductImg = productid!=-1?  productImgProvider.GetAllByProductId(productid):productImgProvider.GetAll();
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            ViewBag.productid = productid;
            LibData.Import import = new LibData.Import();
            import.WarehouseId = warehouseid;
            import.ImportUnitId = importunitid;
            import.Amount = 0;
            import.Warehouse = warehouse != null ? warehouse : new LibData.Warehouse();
            if (id.HasValue)
            {
                import = new LibData.Provider.ImportProvider().GetById(id.Value);
            }
           
            return View(import);
        }
        [HttpPost]
        public ActionResult AddImport(LibData.Import model, int productimgid , int SizeId, int productid)
        {
            LibData.Provider.ProductImgProvider productImgProvider = new LibData.Provider.ProductImgProvider();
            var productimg = productImgProvider.GetById(productimgid);
            ViewBag.productid = productid;
            ViewBag.Size = new LibData.Provider.SizeProvider().GetAllBySex(productimg.Product.Type.Value);
            ViewBag.ProductImg = productid != -1 ? productImgProvider.GetAllByProductId(productid) : productImgProvider.GetAll();
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            if (model.Amount.Value < 0)
            {
                ModelState.AddModelError("Amount", "Số lượng không khả dụng");
            }
            if (model.Price.HasValue)
            {
                if (model.Price.Value <= 10000 || model.Price.Value >= 2000000000)
                {
                    ModelState.AddModelError("Price", "Giá không khả dụng");
                }
            }else
            {
                ModelState.AddModelError("Price", "Giá nhập không được bỏ trống");
            }

            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (importProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);

                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
                else
                {
                    LibData.Warehouse warehouse = warehouseProvider.GetBySize(productimgid, SizeId)??new LibData.Warehouse();
                    if (warehouse.Id > 0 )
                    {
                        model.WarehouseId = warehouse.Id;
                        if (importProvider.Insert(model))
                        {
                            Response.StatusCode = (int)HttpStatusCode.Created;
                            model.Warehouse = warehouse;
                            return View(model);
                        }
                    }
                    else
                    {
                        warehouse.SizeId = SizeId;
                        warehouse.ProductImgId = productimgid;
                        warehouse.Status = 1;
                        warehouse.Discount = 0;
                        warehouse.Amount = 0;
                        if (warehouseProvider.Insert(warehouse))
                        {
                            model.WarehouseId = warehouse.Id;
                            if (importProvider.Insert(model))
                            {
                                Response.StatusCode = (int)HttpStatusCode.Created;
                                model.Warehouse = warehouse;
                                return View(model);
                            }
                        }
                    }
                      
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
            }
            return View(model);
        }
    }
}
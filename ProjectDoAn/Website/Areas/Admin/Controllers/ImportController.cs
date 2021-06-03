using PagedList;
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

    [CustomAuthorize("SuperAdmin")]
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
        public ActionResult ListImport(int importunitid = -1, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.importunitid = importunitid;
            int skip = (page - 1) * size;
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
            var list = importProvider.GetAllByKey( importunitid, skip, size);
            var count = importProvider.CountAllByKey( importunitid);
            StaticPagedList<LibData.Import> pagedList = new StaticPagedList<LibData.Import>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddImport(int ?id, int? importunitid)
        {
         
            LibData.Import import = new LibData.Import();
            import.ImportUnitId = importunitid;
            import.ImportDetails = new List<LibData.ImportDetail>();
            if (id.HasValue)
            {
                import = new LibData.Provider.ImportProvider().GetById(id.Value);
            }
            import.Price = 0;
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            return View(import);
        }
        [HttpPost]
        public ActionResult AddImport(LibData.Import model)
        {
            int total = 0;
            LibData.Provider.ImportUnitProvider  importUnitProvider= new LibData.Provider.ImportUnitProvider();
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            if (model.ImportUnitId.HasValue)
            {
                if (!importUnitProvider.GetAll().Select(x => x.Id).Contains(model.ImportUnitId.Value))
                {
                    ModelState.AddModelError("ImportUnitId", "Nhà cung cấp không tồn tại.");
                }
            }
            else
            {
                ModelState.AddModelError("ImportUnitId", "Vui lòng chọn nhà cung cấp.");
            }
            if (model.ImportDetails == null)
            {
                ModelState.AddModelError("error", "Vui lòng thêm sản phẩm vào phiếu nhập.");
            }
            else
            {
               var check = model.ImportDetails.GroupBy(x => x.WarehouseId.Value).ToList();
                if (model.ImportDetails.Count != check.Count)
                {
                    ModelState.AddModelError("error", "Lỗi.");
                }
                else
                {
                    foreach (var item in model.ImportDetails)
                    {
                        LibData.Warehouse warehouse = warehouseProvider.GetById(item.WarehouseId.Value);
                        if (warehouse != null)
                        {
                            if(item.Price!=null&&item.Price>10000&& item.Amount != null && item.Amount > 0)
                            {
                                warehouse.Amount += item.Amount;
                                warehouse.UpdateDate = DateTime.Now;
                                total += item.Price.Value;
                            }
                            else
                            {
                                ModelState.AddModelError("error", "Lỗi.");
                                break;
                            }
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var item in model.ImportDetails)
                {
                    item.CreateDate = DateTime.Now;
                    item.Status = 1;
                }
                model.CreateDate = DateTime.Now;
                model.Status = 1;
                model.Price = total;
                if (importProvider.Insert(model))
                {
                    warehouseProvider.Update();
                    Response.StatusCode = (int)HttpStatusCode.Created;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateImport(LibData.Import model)
        {
            int total = 0;
            LibData.Provider.ImportUnitProvider importUnitProvider = new LibData.Provider.ImportUnitProvider();
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
            LibData.Provider.WarehouseProvider warehouseProvider = new LibData.Provider.WarehouseProvider();
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            if (model.ImportUnitId.HasValue)
            {
                if (!importUnitProvider.GetAll().Select(x => x.Id).Contains(model.ImportUnitId.Value))
                {
                    ModelState.AddModelError("ImportUnitId", "Nhà cung cấp không tồn tại.");
                }
            }
            else
            {
                ModelState.AddModelError("ImportUnitId", "Vui lòng chọn nhà cung cấp.");
            }
            if (model.ImportDetails == null)
            {
                ModelState.AddModelError("error", "Vui lòng thêm sản phẩm vào phiếu nhập.");
            }
            else
            {
                var check = model.ImportDetails.GroupBy(x => x.WarehouseId.Value).ToList();
                if (model.ImportDetails.Count != check.Count)
                {
                    ModelState.AddModelError("error", "Lỗi.");
                }
                else
                {
                    foreach (var item in model.ImportDetails)
                    {
                        LibData.Warehouse warehouse = warehouseProvider.GetById(item.WarehouseId.Value);
                        if (warehouse != null)
                        {
                            if (item.Price != null && item.Price > 10000 && item.Amount != null && item.Amount > 0)
                            {
                                total += item.Price.Value;
                            }
                            else
                            {
                                ModelState.AddModelError("error", "Lỗi.");
                                break;
                            }
                        }
                    }
                }
            }
            model.Price = total;
            return View("AddImport", model);
        }
    }
}
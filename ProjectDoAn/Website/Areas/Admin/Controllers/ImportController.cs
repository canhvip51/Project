using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Website.Areas.Admin.Controllers
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
            ViewBag.ImportUnit = new LibData.Provider.ImportUnitProvider().GetAll();
            return View(import);
        }
        [HttpPost]
        public ActionResult AddImport(LibData.Import model)
        {
            LibData.Provider.ImportUnitProvider  importUnitProvider= new LibData.Provider.ImportUnitProvider();
            LibData.Provider.ImportProvider importProvider = new LibData.Provider.ImportProvider();
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
                ModelState.AddModelError("Error", "Vui lòng thêm sản phẩm vào phiếu nhập.");
            }
            if (ModelState.IsValid)
            {
                //if (importProvider.Insert(model))
                //{
                //    Response.StatusCode = (int)HttpStatusCode.Created;
                //}
            }
            return View(model);
        }
    }
}
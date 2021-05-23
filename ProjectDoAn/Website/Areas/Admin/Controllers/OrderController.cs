using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Website.Areas.Controllers
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
        public ActionResult AddOrder(int? id)
        {
            LibData.ImportUnit importUnit = new LibData.ImportUnit();
            if (id.HasValue)
            {
                importUnit = new LibData.Provider.ImportUnitProvider().GetById(id.Value);
            }
            return View(importUnit);
        }
        [HttpPost]
        public ActionResult AddImportUnit(LibData.Order model)
        {
            LibData.Provider.OrderProvider importUnitProvider = new LibData.Provider.OrderProvider();
            //if (string.IsNullOrEmpty(model.Name))
            //{
            //    ModelState.AddModelError("Name", "Tên nhà cung cấp không được để trống");
            //}
            //if (string.IsNullOrEmpty(model.Address))
            //{
            //    ModelState.AddModelError("Address", "Địa chỉ nhà cung cấp không được để trống");
            //}
            //if (string.IsNullOrEmpty(model.Phone))
            //{
            //    ModelState.AddModelError("Address", "Số điện thoại không được để trống");
            //}
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (importUnitProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);

                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
                else
                {
                    if (importUnitProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                    ModelState.AddModelError("Error", "Lỗi hệ thống");
                }
            }
            return View(model);
        }
    }
}
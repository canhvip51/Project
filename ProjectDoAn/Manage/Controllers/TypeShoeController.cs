using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    public class TypeShoeController : Controller
    {
        // GET: TypeShoe
        public ActionResult Index(string keysearch,int page = 1, int size = 10)
        {
            ViewBag.keysearch = keysearch;
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListType(string keysearch,int page = 1, int size = 10)
        {
            ViewBag.keysearch = keysearch;
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.TypeShoeProvider typeShoeProvider = new LibData.Provider.TypeShoeProvider();
            var list = typeShoeProvider.GetAllByKey(keysearch,skip, size);
            var count = typeShoeProvider.CountAllByKey(keysearch);
            StaticPagedList<LibData.TypeSho> pagedList = new StaticPagedList<LibData.TypeSho>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddType(int? id)
        {
            LibData.TypeSho typeSho= new LibData.TypeSho();
            if (id.HasValue)
            {
                typeSho = new LibData.Provider.TypeShoeProvider().GetById(id.Value);
            }
            return View(typeSho);
        }
        [HttpPost]
        public ActionResult AddType(LibData.TypeSho model)
        {
            LibData.Provider.TypeShoeProvider typeShoeProvider = new LibData.Provider.TypeShoeProvider();
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Kiểu giày không được để trống");
            }
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (typeShoeProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    if (typeShoeProvider.Insert(model))
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
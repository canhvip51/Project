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

    [CustomAuthorize("Admin", "Manager")]
    public class SlideController : Controller
    {
        public const string _ImagesPath = "~/Images/Slider";
        // GET: Slide
        public ActionResult Index(int status = -1  ,int page = 1, int size = 5)
        {
            ViewBag.page = page;
            ViewBag.status = status;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListSlide(int status = -1 ,int page = 1, int size = 5)
        {
            ViewBag.status = status;
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.SlideProvider slideProvider = new LibData.Provider.SlideProvider();
            var list = slideProvider.GetAllByStatus(status, skip, size);
            var count = slideProvider.CountAllByStatus(status);
            StaticPagedList<LibData.Slide> pagedList = new StaticPagedList<LibData.Slide>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddSlide(int ?id)
        {
            LibData.Slide slide = new LibData.Slide();
            if (id.HasValue)
            {
                slide = new LibData.Provider.SlideProvider().GetById(id.Value);
            }
            return View(slide);
        }
        [HttpPost]
        public ActionResult AddSlide(LibData.Slide model, HttpPostedFileBase UrlFile)
        {
            LibData.Provider.SlideProvider slideProvider = new LibData.Provider.SlideProvider();
            if (model.Id == 0 && UrlFile == null)
            {
                ModelState.AddModelError("UrlFlie", "Thêm ảnh");
            }
            if (UrlFile != null)
            {
                try
                {
                    string fileName = Guid.NewGuid() + Path.GetFileName(UrlFile.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    UrlFile.SaveAs(path);
                    model.UrlFile = fileName;
                }
                catch (Exception)
                {

                    ModelState.AddModelError("UrlFlie", "Ảnh bị lỗi");
                }
           
            }
            if (ModelState.IsValid)
            {
               
                if (model.Id > 0)
                {
                    var old = slideProvider.GetById(model.Id);
                    old.UpdateDate = DateTime.Now;
                    old.Status = model.Status;
                    if (UrlFile != null)
                    {
                     
                        old.UrlFile = model.UrlFile;
                    }
                    
                    if (slideProvider.Update())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View("AddSlide", model);
                    }
                }
                else
                {
                    model.Name = "SLIDE" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    model.CreateDate = DateTime.Now;
                    if (slideProvider.Insert(model))
                    {
                        model.OrderNumber = model.Id;
                        if (slideProvider.Update())
                        {
                            Response.StatusCode = (int)HttpStatusCode.Created;
                            return View("AddSlide", model);
                        }
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ChangeOrder(int id)
        {
            ViewBag.ListSlide = new LibData.Provider.SlideProvider().GetAllByStatus((int)LibData.Configuration.SlideConfig.Status.SHOW);
            ViewBag.id = id;
            ViewBag.replaceorderid = 0;
            return View();
        }
        [HttpPost]
        public ActionResult ChangeOrder(int id, int replaceorderid)
        {
            ViewBag.id = id;
            ViewBag.replaceorderid = replaceorderid;
            LibData.Provider.SlideProvider slideProvider = new LibData.Provider.SlideProvider();
            ViewBag.ListSlide = slideProvider.GetAllByStatus((int)LibData.Configuration.SlideConfig.Status.SHOW);
            LibData.Slide slide = slideProvider.GetById(id);
            LibData.Slide slide1 = slideProvider.GetById(replaceorderid);
            if (slide == null)
            {
                ModelState.AddModelError("id", "Lỗi");
            }
            if (slide1 == null)
            {
                ModelState.AddModelError("replaceorderid", "Lỗi");
            }
            if (ModelState.IsValid)
            {
                int temp=slide.OrderNumber;
                slide.OrderNumber = slide1.OrderNumber;
                slide1.OrderNumber = temp;
                slide.UpdateDate = DateTime.Now;
                slide1.UpdateDate = DateTime.Now;
                if (slideProvider.Update())
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return View();
                }
                ModelState.AddModelError("error", "Lỗi");
                return View();
            }
            return View();
        }
        public bool Delete(int id)
        {
            LibData.Provider.SlideProvider slideProvider = new LibData.Provider.SlideProvider();
            LibData.Slide slide = slideProvider.GetById(id);
            if (slide != null)
            {
                if (slideProvider.Delete(slide))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
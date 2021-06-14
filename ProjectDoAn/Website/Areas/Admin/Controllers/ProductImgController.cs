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
    public class ProductImgController : Controller
    {
        public const string _ImagesPath = "~/Images/Products";
        // GET: ProductImg
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListProductImg(int productid ,int page = 1, int size = 5)
        {
            ViewBag.productid = productid;
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.ProductImgProvider productImg = new LibData.Provider.ProductImgProvider();
            var list = productImg.GetAllByProductId(productid,skip, size);
            var count = productImg.CountAllByProductId(productid);
            StaticPagedList<LibData.ProductImg> pagedList = new StaticPagedList<LibData.ProductImg>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddProductImg(int? id,int productid)
        {
            LibData.ProductImg productImg = new LibData.ProductImg();
            productImg.ProductId = productid;
            if (id.HasValue)
            {
                productImg = new LibData.Provider.ProductImgProvider().GetById(id.Value);
            }
            return View(productImg);
        }
        [HttpPost]
        public ActionResult AddProductImg(LibData.ProductImg model, HttpPostedFileBase Url)
        {
            LibData.Provider.ProductImgProvider productImgProvider = new LibData.Provider.ProductImgProvider();
            if (model.Id==0 && Url==null)
            {
                ModelState.AddModelError("Url", "Thêm ảnh giày");
            }
            if (string.IsNullOrEmpty(model.Color))
            {
                ModelState.AddModelError("Color", "Nhập màu");
            }else if (productImgProvider.CheckColor(model.Color))
            {
                ModelState.AddModelError("Color", "Màu đã tồn tại");
            }
            if (ModelState.IsValid)
            {
                if(Url!=null)
                {
                    string fileName = Guid.NewGuid() + Path.GetFileName(Url.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    Url.SaveAs(path);
                    model.Url = fileName;
                }
                if (model.Id > 0)
                {
                    if (Url == null)
                    {
                        var old = productImgProvider.GetById(model.Id);
                        model.Url = old.Url;
                    }
                    if (productImgProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return PartialView("AddProductImg", model);
                    }
                }
                else
                {
                    if (productImgProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return PartialView("AddProductImg",model);
                    }
                }
            }
            return PartialView("AddProductImg", model);
        }
        public bool Delete(int id)
        {
            LibData.Provider.ProductImgProvider productImgProvider = new LibData.Provider.ProductImgProvider();
            LibData.ProductImg productImg = productImgProvider.GetById(id);
            if (productImg != null)
            {
                productImg.IsDelete = 1;
                productImg.UpdateDate = DateTime.Now;
                if (productImgProvider.Update())
                    return true;
            }

            return false;
        }
    }
}
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
    public class ProductController : Controller
    {
        public const string _ImagesPath = "~/Images/Products";
        // GET: Product
        public ActionResult Index(string keysearch,int sex=-1, int brandid=-1, int status = -1, int page = 1, int size = 10)
        {
            ViewBag.Brand = new LibData.Provider.BrandProvider().GetAll();
            ViewBag.keysearch = keysearch;
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.sex = sex;
            ViewBag.status = status;
            ViewBag.brandid = brandid;
            return View();
        }
        public ActionResult ListProduct(string keysearch, int sex = -1, int brandid = -1, int status = -1, int page = 1, int size = 10)
        {
            ViewBag.keysearch = keysearch;
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.brandid = brandid;
            ViewBag.sex = sex;
            ViewBag.status = status;
            int skip = (page - 1) * size;
            LibData.Provider.ProductProvider productProvider = new LibData.Provider.ProductProvider();
            var list = productProvider.GetAllByKey(keysearch,brandid,sex,status, skip, size);
            var count = productProvider.CountAllByKey(keysearch, brandid, sex, status);
            StaticPagedList<LibData.Product> pagedList = new StaticPagedList<LibData.Product>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddProduct(int? id)
        {
            //ViewBag.Type = new LibData.Provider.TypeShoeProvider().GetAll();
            ViewBag.Brand = new LibData.Provider.BrandProvider().GetAll();
            LibData.Product product = new LibData.Product();
            product.Discount = 0;
            product.Price = 0;
            if (id.HasValue)
            {
                product = new LibData.Provider.ProductProvider().GetById(id.Value);
            }
            return View(product);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AddProduct(LibData.Product model, HttpPostedFileBase AvatarUrl)
        {

            model.Discount = model.Discount ?? 0;
            //ViewBag.Type = new LibData.Provider.TypeShoeProvider().GetAll();
            ViewBag.Brand = new LibData.Provider.BrandProvider().GetAll();
            LibData.Provider.ProductProvider productProvider = new LibData.Provider.ProductProvider();

            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Tên giày không được để trống");
            }
            else if(productProvider.CheckNameAndType(model))
            {
                ModelState.AddModelError("Name", "Tên giày đã tồn tại");
            }
            if (model.Price<50000)
            {
                ModelState.AddModelError("Price", "Giá không khả dụng");
            }
            if (model.Price == null)
            {
                ModelState.AddModelError("Price", "Giá không được để trống");
            }
            if (model.Discount < 0 || model.Discount>99)
            {
                ModelState.AddModelError("Discount", "Khuyễn mãi không khả dụng");
            }
            if (model.Id == 0 && AvatarUrl == null)
            {
                ModelState.AddModelError("AvatarUrl", "Thêm ảnh giày");
            }
            if (AvatarUrl != null)
            {
                try
                {
                    string fileName = Guid.NewGuid() + Path.GetFileName(AvatarUrl.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    AvatarUrl.SaveAs(path);
                    model.AvatarUrl = fileName;
                }
                catch (Exception)
                {
                    ModelState.AddModelError("AvatarUrl", "Thêm ảnh giày bị lỗi");
                }

            }
            if (ModelState.IsValid)
            {
              
                if (model.BrandId < 0)
                    model.BrandId = null;
                if (model.Id > 0)
                {
                    if (AvatarUrl == null)
                    {
                        var old = productProvider.GetById(model.Id);
                        model.AvatarUrl = old.AvatarUrl;
                    }
                    if (productProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    if (productProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        public void UpdateCode()
        {
            new LibData.Provider.WarehouseProvider().UpdateCode();
        }
        [HttpGet]
        public ActionResult PromotionProduct()
        {
            ViewBag.discount = 0;
            ViewBag.brandid = new List<int>();
            ViewBag.productid = new List<int>();
            ViewBag.brand = new LibData.Provider.BrandProvider().GetAll();
            ViewBag.product = new LibData.Provider.ProductProvider().GetAll();
            return View();

        }
        [HttpPost]
        public ActionResult PromotionProduct(List<int> productid, List<int> brandid,int? discount)
        {
            
            discount = discount ?? 0;
            if(discount>100|| discount < 0)
            {
                ModelState.AddModelError("discount","Khuyễn mãi không khả dụng");
            }
            brandid = brandid ?? new List<int>();
            productid = productid ?? new List<int>();
            ViewBag.brand = new LibData.Provider.BrandProvider().GetAll();
            ViewBag.product = new LibData.Provider.ProductProvider().GetAll();
            ViewBag.brandid = brandid;
            ViewBag.discount = discount;
            ViewBag.productid = productid;
            LibData.Provider.ProductProvider productProvider = new LibData.Provider.ProductProvider();
            if (ModelState.IsValid)
            {
                if (productProvider.DiscountProduct(productid, brandid, discount.Value))
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
            LibData.Provider.ProductProvider productProvider = new LibData.Provider.ProductProvider();
            LibData.Product product = productProvider.GetById(id);
            if (product != null)
            {
                product.IsDelete = 1;
                product.UpdateDate = DateTime.Now;
                if (productProvider.Update())
                    return true;
            }

            return false;
        }
    }
}
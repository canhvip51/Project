using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("Admin", "Manager")]
    public class PromotionController : Controller
    {
        // GET: Admin/Promotion
        public ActionResult Index(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            return View();
        }
        public ActionResult ListPromotion(int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            int skip = (page - 1) * size;
            LibData.Provider.PromotionProvider promotionProvider = new LibData.Provider.PromotionProvider();
            var list = promotionProvider.GetAll(skip, size);
            var count = promotionProvider.CountAll();
            StaticPagedList<LibData.Promotion> pagedList = new StaticPagedList<LibData.Promotion>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddPromotion(int? id)
        {
            LibData.Promotion promotion = new LibData.Promotion();
            promotion.Discount = 0;
            if (id.HasValue)
            {
                promotion = new LibData.Provider.PromotionProvider().GetById(id.Value);
            }
            
            return View(promotion);
        }
        [HttpPost]
        public ActionResult AddPromotion(LibData.Promotion model,string StartDate, string ExpiredDate)
        {
            DateTime d;
            if (!string.IsNullOrEmpty(StartDate))
            {
                if (DateTime.TryParseExact(StartDate, "dd-MM-yyyy",
                               null, DateTimeStyles.None,
                               out d))
                {
                    ModelState.Remove("StartDate");
                    model.StartDate = d;
                }
                else
                {
                    ModelState.Remove("StartDate");
                    model.StartDate = null;
                    ModelState.AddModelError("StartDate", "Giá trị không phù hợp");
                }
            }
            if (!string.IsNullOrEmpty(ExpiredDate))
            {
                model.Discount = model.Discount ?? 0;
                if (DateTime.TryParseExact(ExpiredDate, "dd-MM-yyyy",
                            null, DateTimeStyles.None,
                            out d))
                {
                    ModelState.Remove("ExpiredDate");
                    model.ExpiredDate = d.AddDays(1);
                }
                else
                {
                    ModelState.Remove("ExpiredDate");
                    model.ExpiredDate = null;
                    ModelState.AddModelError("ExpiredDate", "Giá trị không phù hợp");
                }
            }
            if(model.StartDate.HasValue && model.ExpiredDate.HasValue)
            {
                if(model.StartDate> model.ExpiredDate)
                    ModelState.AddModelError("error", "Thời gian bắt đầu phải nhỏ hơn thời gian kết thúc");
            }
            LibData.Provider.PromotionProvider promotionProvider = new LibData.Provider.PromotionProvider();
            if (string.IsNullOrEmpty(model.KeyCode))
            {
                ModelState.AddModelError("KeyCode", "Mã khuyễn mãi không được để trống");
            } else if (promotionProvider.CheckKeyCode(model.KeyCode))
            {
                ModelState.AddModelError("KeyCode", "Mã khuyễn mãi đã tồn tại");
            }
            if (model.Discount.HasValue)
            {
                if (model.Discount<0 || model.Discount > 99)
                {
                    ModelState.AddModelError("Discount", "Giảm giá không khả dụng");
                }
            }
         
            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    LibData.Promotion promotion = promotionProvider.GetById(model.Id);
                    promotion.StartDate = model.StartDate;
                    promotion.ExpiredDate = model.ExpiredDate;
                    promotion.Amount = model.Amount;
                    promotion.Discount = model.Discount;
                    if (promotionProvider.Update())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    model.CreateDate = DateTime.Now;
                    if (promotionProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        public bool DeletePromotion(int id)
        {
            LibData.Provider.PromotionProvider promotionProvider = new LibData.Provider.PromotionProvider(); 
              LibData.Promotion  promotion = promotionProvider.GetById(id);
            if (promotion != null)
            {
                promotion.IsDelete = 1;
                promotion.UpdateDate = DateTime.Now;
                if (promotionProvider.Update())
                    return true;
            }
            return false;
        }
    }
}
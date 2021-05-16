using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Category(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var danhmucsanpham = new LibData.Provider.DanhMucSanPhamProvider().getbyTenUrl(id);
                ViewBag.Title = danhmucsanpham.TenDanhMuc;
                var models = new LibData.Provider.SanPhamProvider().getAllByIdDanhMucSanPham(danhmucsanpham.Id);
                return View(models);
            }
            return View(new LibData.Provider.SanPhamProvider().getAll());
            
        }
        public ActionResult Detail(string id)
        {
            var sanpham = new LibData.Provider.SanPhamProvider().getByTenUrl(id);
            ViewBag.Title = sanpham.TenSanPham;
            ViewData["SanPhamImages"]= new LibData.Provider.HinhAnhSanPhamProvider().getAllbyIdSanPham(sanpham.Id);
            return View(sanpham);
        }
        public ActionResult Search(string name)
        {
            ViewBag.Title = "Tìm kiếm từ khóa : "+ name;
            var models = new LibData.Provider.SanPhamProvider().getAllByContentName(name);
            return View(models);

        }
    }
}
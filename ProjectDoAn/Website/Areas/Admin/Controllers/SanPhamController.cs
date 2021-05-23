using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Manage.Controllers
{
    
    public class SanPhamController : Controller
    {
        public const string _ImagesPath = "~/Images/Products";
        public const string _ImagesPathDrafts = "~/Images/Drafts";
        // GET: SanPham
        public ActionResult Index()
        {
            return View(new LibData.Provider.SanPhamProvider().getAll());
        }
        public ActionResult Create()
        {
            string key = Guid.NewGuid().ToString();
            ViewBag.key = key;
            Session["Files_"+ key] = new List<string>();
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            ViewData["ThuongHieus"] = new LibData.Provider.ThuongHieuProvider().getAll();
            return View(new LibData.SanPham());
        }
        [HttpPost , ValidateInput(false)]
        public ActionResult Create(LibData.SanPham model, HttpPostedFileBase TenFileImage,string key)
        {
            ViewBag.key = key;
            var list = Session["Files_" + key] as List<string> ?? new List<string>();
            
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            ViewData["ThuongHieus"] = new LibData.Provider.ThuongHieuProvider().getAll();
            if (string.IsNullOrEmpty(model.TenSanPham))
            {
                ModelState.AddModelError("TenSanPham", "Vui lòng nhập giá trị");
            }
            if (model.IdDanhMuc == 0)
            {
                ModelState.AddModelError("IdDanhMuc", "Vui lòng nhập giá trị");
            }
            if (model.IdThuongHieu == 0)
            {
                ModelState.AddModelError("IdThuongHieu", "Vui lòng nhập giá trị");
            }
            //if (string.IsNullOrEmpty(model.Model))
            //{
            //    ModelState.AddModelError("Model", "Vui lòng nhập giá trị");
            //}
            if (string.IsNullOrEmpty(model.ChatLieu))
            {
                ModelState.AddModelError("ChatLieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.HuongDanBaoQuan))
            {
                ModelState.AddModelError("HuongDanBaoQuan", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.HuongDanSudung))
            {
                ModelState.AddModelError("HuongDanSudung", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            if (TenFileImage == null)
            {
                ModelState.AddModelError("TenFileImage", "Vui lòng chọn file");
            }
            if (!ModelState.IsValid)
            {
                foreach(var item in list)
                {
                    System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPathDrafts), key + "_" + item));
                }
                return View(model);
            }
            try
            {
                string fileName = Guid.NewGuid() + Path.GetFileName(TenFileImage.FileName);
                string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                TenFileImage.SaveAs(path);
                model.TenFileImage = fileName;
                model.Model = "VP";
                new LibData.Provider.SanPhamProvider().Insert(model);
                var modelnew = new LibData.Provider.SanPhamProvider().getByTenUrl(model.TenUrl);
                
                foreach(var item in list)
                {
                    LibData.HinhAnhSanPham modelhinaanh = new LibData.HinhAnhSanPham()
                    {
                        Active = 1,
                        IdSanPham = modelnew.Id,
                        NgayTao=DateTime.Now,
                        TenFile=item
                    };
                    
                    string pathcur = Path.Combine(Server.MapPath(_ImagesPathDrafts), item);
                    string pathnew = Path.Combine(Server.MapPath(_ImagesPath), item);
                    System.IO.File.Move(pathcur, pathnew);
                }
                return RedirectToAction("Index", "SanPham");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            string key = Guid.NewGuid().ToString();
            ViewBag.key = key;
            Session["Files_" + key] = new List<string>();
            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            ViewData["ThuongHieus"] = new LibData.Provider.ThuongHieuProvider().getAll();
            ViewData["HinhAnhSanPhams"] = new LibData.Provider.HinhAnhSanPhamProvider().getAllbyIdSanPham(id);
            return View(new LibData.Provider.SanPhamProvider().getById(id));
        }
        [HttpPost , ValidateInput(false)]
        public ActionResult Edit(LibData.SanPham model, HttpPostedFileBase TenFileImage,string key)
        {
            ViewBag.key = key;
            var list = Session["Files_" + key] as List<string> ?? new List<string>();

            ViewData["DanhMucSanPhams"] = new LibData.Provider.DanhMucSanPhamProvider().getAll();
            ViewData["ThuongHieus"] = new LibData.Provider.ThuongHieuProvider().getAll();
            if (string.IsNullOrEmpty(model.TenSanPham))
            {
                ModelState.AddModelError("TenSanPham", "Vui lòng nhập giá trị");
            }
            if (model.IdDanhMuc == 0)
            {
                ModelState.AddModelError("IdDanhMuc", "Vui lòng nhập giá trị");
            }
            if (model.IdThuongHieu == 0)
            {
                ModelState.AddModelError("IdThuongHieu", "Vui lòng nhập giá trị");
            }
            //if (string.IsNullOrEmpty(model.Model))
            //{
            //    ModelState.AddModelError("Model", "Vui lòng nhập giá trị");
            //}
            if (string.IsNullOrEmpty(model.ChatLieu))
            {
                ModelState.AddModelError("ChatLieu", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.HuongDanBaoQuan))
            {
                ModelState.AddModelError("HuongDanBaoQuan", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.HuongDanSudung))
            {
                ModelState.AddModelError("HuongDanSudung", "Vui lòng nhập giá trị");
            }
            if (string.IsNullOrEmpty(model.TenUrl))
            {
                ModelState.AddModelError("TenUrl", "Vui lòng nhập giá trị");
            }
            //if (TenFileImage == null)
            //{
            //    ModelState.AddModelError("TenFileImage", "Vui lòng chọn file");
            //}
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                if (TenFileImage != null)
                {
                    var modelcur = new LibData.Provider.SanPhamProvider().getById(model.Id);
                    System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPath), modelcur.TenFileImage));
                    string fileName = Guid.NewGuid() + Path.GetFileName(TenFileImage.FileName);
                    string path = Path.Combine(Server.MapPath(_ImagesPath), fileName);
                    TenFileImage.SaveAs(path);
                    model.TenFileImage = fileName;
                }
                model.Model = "VP";
                new LibData.Provider.SanPhamProvider().Update(model);
                foreach (var item in list)
                {
                    LibData.HinhAnhSanPham modelhinaanh = new LibData.HinhAnhSanPham()
                    {
                        Active = 1,
                        IdSanPham = model.Id,
                        NgayTao = DateTime.Now,
                        TenFile = item
                    };
                    new LibData.Provider.HinhAnhSanPhamProvider().Insert(modelhinaanh);
                    string pathcur = Path.Combine(Server.MapPath(_ImagesPathDrafts), item);
                    string pathnew = Path.Combine(Server.MapPath(_ImagesPath), item);
                    System.IO.File.Move(pathcur, pathnew);
                }
                return RedirectToAction("Index", "SanPham");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex;
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult AddFileDrafts(string key)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  
                        HttpPostedFileBase file = files[i];
                        string fname;
                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string filename = fname;
                        //String unique = Guid.NewGuid().ToString().Replace("-", "");
                        string name = key + "_" + fname;
                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath(_ImagesPathDrafts), name);
                        file.SaveAs(fname);
                        List<string> listfile = new List<string>();
                        listfile = Session["Files_" + key] as List<string>;
                        listfile.Add(name);
                        return Json(new { success = true, responseText = "Upload successfuly!", file = name }, JsonRequestBehavior.AllowGet);
                    }
                    
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, responseText = ex.ToString() }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                return Json(new { success = false, responseText = "None File select!" }, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        [HttpPost]
        public ActionResult RemoveFileDrafts(string file,string key)
        {
            System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPathDrafts), key+"_"+file));
            List<string> listfile = new List<string>();
            listfile = Session["Files_" + key] as List<string>;
            listfile.Remove(key + "_" + file);
            Session["Files_" + key] = listfile;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteImage(int id)
        {
            var model = new LibData.Provider.HinhAnhSanPhamProvider().getById(id);
            try
            {
                new LibData.Provider.HinhAnhSanPhamProvider().Delete(model);
                System.IO.File.Delete(Path.Combine(Server.MapPath(_ImagesPath), model.TenFile));
            }
            catch (Exception)
            {}
            return View(new LibData.Provider.HinhAnhSanPhamProvider().getAllbyIdSanPham(model.IdSanPham));
        }
    }
}
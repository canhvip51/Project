using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Website.Infrastructure;

namespace Website.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]

    [CustomAuthorize("Admin")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult CustomerUser(string keysearch, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.keysearch = keysearch;
            return View();
        }
        public ActionResult ListCustomerUser(string keysearch, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            var list = userProvider.GetAllUserByRoleAndKey(keysearch, (int)LibData.Configuration.UserConfig.Role.CUSTOMER, skip, size);
            var count = userProvider.CountAllUserByRoleAndKey(keysearch, (int)LibData.Configuration.UserConfig.Role.CUSTOMER);
            StaticPagedList<LibData.User> pagedList = new StaticPagedList<LibData.User>(list, page, size, count);
            return View(pagedList);
        }
        public ActionResult ManagerUser(string keysearch, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.keysearch = keysearch;
            return View();
        }
        public ActionResult ListManagerUser(string keysearch, int page = 1, int size = 10)
        {
            ViewBag.page = page;
            ViewBag.size = size;
            ViewBag.keysearch = keysearch;
            int skip = (page - 1) * size;
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            var list = userProvider.GetAllUserByRoleAndKey(keysearch, (int)LibData.Configuration.UserConfig.Role.MANAGER, skip, size);
            var count = userProvider.CountAllUserByRoleAndKey(keysearch, (int)LibData.Configuration.UserConfig.Role.MANAGER);
            StaticPagedList<LibData.User> pagedList = new StaticPagedList<LibData.User>(list, page, size, count);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult AddManagerUser(int? id)
        {
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.User user = new LibData.User();
            if (id.HasValue)
            {
                user = new LibData.Provider.UserProvider().GetById(id.Value);
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult AddManagerUser(LibData.User model)
        {
            ViewBag.Province = new LibData.Provider.ExtendProvider().GetAddProvice();
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "Tên đăng nhập không được để trống");
            }
            else if (userProvider.CheckExistUserName(model) && model.Id < 1)
            {
                ModelState.AddModelError("UserName", "Tên đăng nhập đã tồn tại");
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "Số điện thoại không được để trống");
            }
            else if (userProvider.CheckExistPhone(model) )
            {
                ModelState.AddModelError("Phone", "Số điện đã tồn tại");
            } else 
            if (model.Phone.Length!=10 || model.Phone[0]!=0)
            {
                ModelState.AddModelError("Phone", "Số điện thoại không phù hợp");
            }
            if (string.IsNullOrEmpty(model.Password) && model.Id < 1)
            {
                ModelState.AddModelError("Password", "Mật khẩu không được để trống");
            }
            if (model.Password != null)
                if (model.Password.Length < 6)
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải lớn hơn 6 ký tự");
                }

            if (ModelState.IsValid)
            {

                if (model.Id > 0)
                {
                    if (userProvider.Update(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
                else
                {
                    model.Password = LibData.Utilities.SecurityHelper.sha256Hash(model.Password).Trim();
                    model.Role = (int)LibData.Configuration.UserConfig.Role.MANAGER;
                    if (userProvider.Insert(model))
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return View(model);
                    }
                }
            }
            return View(model);
        }

        public bool DeleteManagerUser(int id)
        {
            return new LibData.Provider.UserProvider().Delete(id);
        }
        public bool Change(int id)
        {
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            var user = userProvider.GetById(id);
            string pass = new LibData.Provider.ConfigProvider().GetDefault_Pass();
            if (user != null)
            {
                user.Password = LibData.Utilities.SecurityHelper.sha256Hash(pass).Trim();
                user.UpdateDate = DateTime.Now;
                if (userProvider.Update())
                    return true; ;
            }
            return false;
        }
    }
}
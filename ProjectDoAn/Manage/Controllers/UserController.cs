using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Manage.Controllers
{
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
            var list = userProvider.GetAllUserByRoleAndKey(keysearch,(int)LibData.Configuration.UserConfig.Role.CUSTOMER, skip, size);
            var count = userProvider.CountAllUserByRoleAndKey(keysearch,(int)LibData.Configuration.UserConfig.Role.CUSTOMER);
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
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "Tên đăng nhập không được để trống");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Mật khẩu không được để trống");
            }
            if (model.Password != null)
                if (model.Password.Length < 6)
                {
                    ModelState.AddModelError("Password", "Mật khẩu phải lớn hơn 6 ký tự");
                }
            if(userProvider.CheckExistUserName(model.UserName))
            {
                ModelState.AddModelError("UserName", "Tên đăng nhập đã tồn tại");
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
    }
}
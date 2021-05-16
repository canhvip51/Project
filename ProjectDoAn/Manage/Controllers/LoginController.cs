using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vbot.Web.Models;

namespace Manage.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string backURL)
        {
            if (Session["User"] != null)
            {
                var user = Session["User"] as LibData.User;
                if (user.Role == (int)LibData.Configuration.UserConfig.Role.SUPERADMIN)
                {
                    return Redirect("/admin/dashboard");
                }
            }
            ViewBag.backURL = backURL;
            if (string.IsNullOrEmpty(backURL))
            {
                ViewBag.backURL = "/admin/dashboard";
            }
            else if (backURL.Contains("LogOut"))
            {
                ViewBag.backURL = "/admin/dashboard";
            }

            Response.AppendHeader("statusCode", "401");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin model, string backURL)
        {
            ViewBag.backURL = backURL;
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "Tài khoản không được để trống");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Mật khẩu không được rỗng");
            }
            if (ModelState.IsValid)
            {
                LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
                var user = userProvider.Login(model.UserName, LibData.Utilities.SecurityHelper.sha256Hash(model.Password));
                if (user != null && user.Status != (int)LibData.Configuration.UserConfig.Status.DEACTIVE && user.Role == (int)LibData.Configuration.UserConfig.Role.SUPERADMIN)
                {
                    Session["User"] = user;
                    //string str = user.AccountOpenFire + "," + user.PasswordOpenFire + "," + user.DomainOpenFire;
                    //Session["KeyOpenFire"] = LibData.Utilities.SecurityHelper.Encrypt(str);
                    if (string.IsNullOrEmpty(backURL))
                    {
                        return RedirectToAction("/admin/dashboard");
                    }
                    else
                    {
                        return Redirect(backURL);
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "Account password is incorrect, please try again.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }
    }
}
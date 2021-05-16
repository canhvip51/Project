using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vbot.Web.Infrastructure;
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
                    return Redirect("/dashboard/index");
                }
            }
            ViewBag.backURL = backURL;
            if (string.IsNullOrEmpty(backURL))
            {
                ViewBag.backURL = "/dashboard/index";
            }
            else if (backURL.Contains("LogOut"))
            {
                ViewBag.backURL = "/dashboard/index";
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
                        return RedirectToAction("/dashboard/index");
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
        [CustomAuthenticationFilter]
        [CustomAuthorize("SuperAdmin")]
        [HttpGet]
        public ActionResult ChangePass()
        {
            
            return View( new LibData.Model.ChangePass());
        }
        [CustomAuthenticationFilter]
        [CustomAuthorize("SuperAdmin")]
            [HttpPost]
        public ActionResult ChangePass(LibData.Model.ChangePass model)
        {
            LibData.Provider.UserProvider userProvider = new LibData.Provider.UserProvider();
            LibData.User user = Session["User"] as LibData.User;
            if (LibData.Utilities.SecurityHelper.sha256Hash(model.oldPass) != user.Password.Trim())
            {
                ModelState.AddModelError("oldPass", "Mật khẩu cũ sai");
                model.oldPass = "";
            }
            if (string.IsNullOrEmpty(model.oldPass))
            {
                ModelState.AddModelError("oldPass", "Mật khẩu cũ không được để trống");
            }
            if (!model.newPass.Equals(model.renewPass))
            {
                ModelState.AddModelError("newPass", "Mật khẩu mới và mât khẩu nhập lại không trùng");
            }
            if (string.IsNullOrEmpty(model.newPass))
            {
                ModelState.AddModelError("newPass", "Mật khẩu mới không được để trống");
                if (string.IsNullOrEmpty(model.renewPass))
                {
                    ModelState.AddModelError("renewPass", "Mật khẩu nhập lại không được để trống");
                }
            }
            if (!string.IsNullOrEmpty(model.newPass))
            {
                if (model.newPass.Length>=6)
                {
                    ModelState.AddModelError("newPass", "Mật khẩu mới phải ít nhất 6 ký tự");
                }
            }
            if (ModelState.IsValid)
            {
                user.Password = LibData.Utilities.SecurityHelper.sha256Hash(model.newPass);
                if (userProvider.UpdatePassword(user))
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return View(model);
                }
            }
            return View(model);
        }

    }
}
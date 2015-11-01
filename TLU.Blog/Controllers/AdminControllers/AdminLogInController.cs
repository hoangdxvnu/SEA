using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;
using TLU.Blog.Helpers;
using TLU.Blog.Controllers;

namespace TLU.Blog.AdminControllers
{
    public class AdminLogInController : Controller
    {
        // GET: AdminLogIn
        public ActionResult logIn()
        {

            return View();
        }
        // POST
        [HttpPost]
        public ActionResult logIn(User Account)
        {
            var result = new AccountModel().LogIn(Account,true);
            if(result==3)
            {
                var Object= new AccountModel().GetUserSession(Account.UserName);
                SessionHelper.SetSesstion(Constant.SESSION_USER, Object);
                SessionHelper.SetSesstion(Constant.SESSION_RULE, new AccountModel().GetListRule(Account.UserName));
                return RedirectToAction("Home", "AdminHome");
            }
            else if(result==-2)
            {
                ModelState.AddModelError("", "Mời bận nhập mật khẩu");
            }
            else if(result==-1)
            {
                ModelState.AddModelError("", "Mời bạn nhập tài khoản");
            }
            else if(result==0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if(result==1)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else if(result==2)
            {
                ModelState.AddModelError("", "Tài khoản không có quyền đang nhập");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            SessionHelper.Remove(Constant.SESSION_USER);
            return RedirectToAction("LogIn", "AdminLogIn");
        }
    }
}
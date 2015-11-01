using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.AdminControllers
{
    public class AdminHomeController : AdminBaseController
    {
        private const int ACCOUNT_ID = 15;
        // GET: AdminHome
        public ActionResult Home()
        {
            ViewBag.Profile = new AccountModel().GetProfileById(ACCOUNT_ID);
            return View();
        }
        public ActionResult LogOut()
        {
            SessionHelper.Remove(Constant.SESSION_USER);
            return RedirectToAction("LogIn", "AdminLogIn");
        }
    }
}
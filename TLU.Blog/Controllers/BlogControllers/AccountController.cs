using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;

namespace TLU.Blog.Controllers.BlogControllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession; 
            var result =  new AccountModel().GetAccount(account.Id);
            return View(result);
        }
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult EditProfile()
        {
            return View();
        }
        public ActionResult EditPassword()
        {
            return View();
        }
    }
}
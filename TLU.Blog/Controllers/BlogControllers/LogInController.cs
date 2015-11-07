using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;

namespace TLU.Blog.Controllers
{
    public class LogInController : BaseController
    {
        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User Account)
        {
            var result = new AccountModel().LogIn(Account);
            if (result == 3)
            {
                var Object = new AccountModel().GetUserSession(Account.UserName);
                SessionHelper.SetSesstion(Constant.SESSION_USER, Object);
                SessionHelper.SetSesstion(Constant.SESSION_RULE, new AccountModel().GetListRule(Account.UserName));
                return RedirectToAction("Index", "Home");
            }
            else if (result == -2)
            {
                ModelState.AddModelError("", "Mời bận nhập mật khẩu");
            }
            else if (result == -1)
            {
                ModelState.AddModelError("", "Mời bạn nhập tài khoản");
            }
            else if (result == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }
            else if (result == 1)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else if (result == 2)
            {
                ModelState.AddModelError("", "Tài khoản không có quyền đang nhập");
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(AccountView Data,string a)
        {
            if(a==null)
            {
                // Using Resource for get text string
                ModelState.AddModelError("","Bạn chưa đồng ý điều khoản");
                return View(Data);
            }
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (Data.Password == Data.ConfirmPassword)
                    {
                        Account account = new Account();
                        account.UserName = Data.UserName;
                        account.Password = Data.Password;
                        // Define constant
                        account.Level = "NORMAL";
                        account.IsActive = true;
                        account.ActiveBy = 0;
                        new AccountModel().CreateAccount(account);
                        Profile profile = new Profile();
                        profile.ID = new AccountModel().GetAccount(Data.UserName).ID;
                        profile.Birthday = Data.Birthday;
                        profile.FirstName = Data.FirstName;
                        profile.SurName = Data.SurName;
                        new AccountModel().CreateProfile(profile);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mã xác nhận mật khẩu không đúng");
                        return View(Data);
                    }
                }
                else
                {
                    return View(Data);
                }
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View(Data);
            }
        }

    }
}
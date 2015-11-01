using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Helpers;
using TLU.Blog.AdminControllers;
using TLU.Blog.Models.DataViews;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminAccountController : AdminBaseController
    {
        // GET: AdminAccount
        [HasRule(RuleId = "VIEW_ACCOUNT")]
        public ActionResult Index(int Page= 1,int PageSize = 10)
        {
            return View(new AccountModel().GetPageListAccount(Page,PageSize));
        }

        // GET: AdminAccount/Details/5
        [HasRule(RuleId = "DETAIL_ACCOUNT")]
        public ActionResult Details(int id)
        {
            return View(id);
        }

        // GET: AdminAccount/Create
        [HasRule(RuleId = "CREATE_ACCOUNT")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAccount/Create
        [HttpPost]
        [HasRule(RuleId = "CREATE_ACCOUNT")]
        public ActionResult Create(AccountView Data)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    if(Data.Password==Data.ConfirmPassword)
                    {
                        Account account = new Account();
                        account.UserName = Data.UserName;
                        account.Password = Data.Password;
                        account.Level = Data.Level;
                        account.IsActive = true;
                        UserSession data = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
                        account.ActiveBy = data.Id;
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

        // GET: AdminAccount/Edit/5
        [HasRule(RuleId = "EDIT_ACCOUNT")]
        public ActionResult Edit(int id)
        {
            return View(id);
        }
        // GET: AdminAccount/Delete/5
        [HasRule(RuleId = "DELETE_ACCOUNT")]
        public ActionResult Delete(int id)
        {
            return View(new AccountModel().GetAccount(id));
        }

        // POST: AdminAccount/Delete/5
        [HttpPost]
        [HasRule(RuleId = "DELETE_ACCOUNT")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new AccountModel().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ProfileDetails(int id)
        {
            return View(new AccountModel().GetProfile(id));
        }
        public ActionResult AccountDetails(int id)
        {
            return View(new AccountModel().GetAccount(id));
        }
        public ActionResult ProfileEdit(int id)
        {
            return View(new AccountModel().GetProfile(id));
        }
        [HttpPost]
        public ActionResult ProfileEdit(int id, Profile Data)
        {

            try
            {
                new AccountModel().EditProfile(id, Data);
                return RedirectToAction("Edit", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult PasswordEdit(int id)
        {
            ViewBag.Id = id;
            return View(new AccountModel().GetAccountViewToEditPassword(id));
        }
        [HttpPost]
        public ActionResult PasswordEdit(int id,AccountView Data)
        {
            if(Data.Password==null||Data.ConfirmPassword==null)
            {
                return View();
            }
            else
            {
                new AccountModel().EditPassword(id, Data.Password);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Lỗi ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.AdminControllers;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminNavigationController : AdminBaseController
    {
        private UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
        // GET: AdminNavigation
        [HasRule(RuleId = "VIEW_NAVIGATION")]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new NavigationModel().GetPageListNavigation(Page,PageSize));
        }

        // GET: AdminNavigation/Details/5
        [HasRule(RuleId = "DETAIL_NAVIGATION")]
        public ActionResult Details(int id)
        {
            var Result = new NavigationModel().GetNavigationById(id);
            return View(Result);
        }

        // GET: AdminNavigation/Create
        [HasRule(RuleId = "CREATE_NAVIGATION")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminNavigation/Create
        [HttpPost]
        [HasRule(RuleId="CREATE_NAVIGATION")]
        public ActionResult Create(Navigation pNewNavigation,string Lang)
        {
            try
            {
                // TODO: Add insert logic here
                if (Lang == "Tiếng Việt")
                {
                    pNewNavigation.LangId = 0;
                }
                else
                {
                    pNewNavigation.LangId = 1;
                }
                pNewNavigation.CreatedBy = account.Id;
                pNewNavigation.CreatedDate = DateTime.Now;
                pNewNavigation.EditBy = account.Id;
                pNewNavigation.EditDate = DateTime.Now;
                pNewNavigation.IsActive = true;
                var check = new NavigationModel().Create(pNewNavigation);
                if (!check)
                {
                    return View(pNewNavigation);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pNewNavigation);
            }
        }

        // GET: AdminNavigation/Edit/5
        [HasRule(RuleId = "EDIT_NAVIGATION")]
        public ActionResult Edit(int id)
        {
            var Result = new NavigationModel().GetNavigationById(id);
            return View(Result);
        }

        // POST: AdminNavigation/Edit/5
        [HttpPost]
        [HasRule(RuleId = "EDIT_NAVIGATION")]
        public ActionResult Edit(int id, Navigation pNewNavigation, string Lang)
        {
            try
            {
                // TODO: Add update logic here
                if (Lang == "Tiếng Việt")
                {
                    pNewNavigation.LangId = 0;
                }
                else
                {
                    pNewNavigation.LangId = 1;
                }
                pNewNavigation.CreatedBy = account.Id;
                pNewNavigation.CreatedDate = DateTime.Now;
                pNewNavigation.EditBy = account.Id;
                pNewNavigation.EditDate = DateTime.Now;
                var check = new NavigationModel().Edit(id, pNewNavigation);
                if (!check)
                {
                    return View(pNewNavigation);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new NavigationModel().GetNavigationById(id));
            }
        }
        // GET: AdminNavigation/Delete/5
        [HasRule(RuleId = "DELETE_NAVIGATION")]
        public ActionResult Delete(int id)
        {
            return View(new NavigationModel().GetNavigationById(id));
        }

        // POST: AdminNavigation/Delete/5
        [HttpPost]
        [HasRule(RuleId = "DELETE_NAVIGATION")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var check = new NavigationModel().Delete(id);
                if (check == true)
                    return RedirectToAction("Index");
                else
                    return View(new NavigationModel().GetNavigationById(id));

            }
            catch
            {
                return View(new NavigationModel().GetNavigationById(id));
            }
        }
    }
}

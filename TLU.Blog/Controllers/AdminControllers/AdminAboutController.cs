using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Controllers;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;
namespace TLU.Blog.AdminControllers
{
    public class AdminAboutController : AdminBaseController
    {
        private UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
        // GET: AdminAbout
        [HasRule(RuleId=("VIEW_ABOUT"))]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new AboutModel().GetPageListAbout(Page,PageSize));
        }

        // GET: AdminAbout/Details/5
        [HasRule(RuleId = ("DETAIL_ABOUT"))]
        public ActionResult Details(int id)
        {
            return View(new AboutModel().GetAboutById(id));
        }

        // GET: AdminAbout/Create
        [HasRule(RuleId = ("CREATE_ABOUT"))]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAbout/Create
        [HttpPost]
        [HasRule(RuleId = ("CREATE_ABOUT"))]
        public ActionResult Create(AboutView pNewAboutView)
        {
            About pNewAbout = new About();
            try
            {
                pNewAbout.Name = pNewAboutView.Name;
                pNewAbout.Descritp = pNewAboutView.Descritp;
                pNewAbout.Content = pNewAboutView.Content;
                pNewAbout.OrderDisplay = pNewAboutView.OrderDisplay;
                pNewAbout.Image = pNewAboutView.Image;
                pNewAbout.IsActive = pNewAboutView.IsActive;
                if(pNewAboutView.LangId=="Tiếng Việt")
                {
                    pNewAbout.LangId = 0;
                }
                else
                {
                    pNewAbout.LangId = 1;
                }
                pNewAbout.CreatedBy = account.Id;
                pNewAbout.CreatedDate = DateTime.Now;
                pNewAbout.EditBy = account.Id;
                pNewAbout.EditDate = DateTime.Now;
                var check = new AboutModel().Create(pNewAbout);
                if(check==true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pNewAboutView);
                }
            }
            catch
            {
                return View(pNewAboutView);
            }
        }

        // GET: AdminAbout/Edit/5
        [HasRule(RuleId = ("EDIT_ABOUT"))]
        public ActionResult Edit(int id)
        {
            var pNewAboutView = new AboutView();
            var Object = new AboutModel().GetAboutById(id);
            pNewAboutView.Name = Object.Name;
            pNewAboutView.Descritp = Object.Descritp;
            pNewAboutView.Content = Object.Content;
            pNewAboutView.OrderDisplay = Object.OrderDisplay;
            pNewAboutView.IsActive = Object.IsActive;
            pNewAboutView.Image = Object.Image;
            if (Object.LangId == 0)
            {
                pNewAboutView.LangId = "Tiếng Việt";
            }
            else
            {
                pNewAboutView.LangId = "Tiếng Anh";
            }
            return View(pNewAboutView);
        }

        // POST: AdminAbout/Edit/5
        [HttpPost]
        [HasRule(RuleId = ("EDIT_ABOUT"))]
        public ActionResult Edit(int id, AboutView pNewAboutView)
        {
            About pNewAbout = new About();
            try
            {
                // TODO: Add update logic here
                pNewAbout.Image = pNewAboutView.Image;
                pNewAbout.Name = pNewAboutView.Name;
                pNewAbout.Descritp = pNewAboutView.Descritp;
                pNewAbout.Content = pNewAboutView.Content;
                pNewAbout.OrderDisplay = pNewAboutView.OrderDisplay;
                pNewAbout.IsActive = pNewAboutView.IsActive;
                if (pNewAboutView.LangId == "Tiếng Việt")
                {
                    pNewAbout.LangId = 0;
                }
                else
                {
                    pNewAbout.LangId = 1;
                }
                pNewAbout.EditBy = account.Id;
                pNewAbout.EditDate = DateTime.Now;
                var check = new AboutModel().Edit(id, pNewAbout);
                if (check == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pNewAboutView);
                }
                
            }
            catch
            {
                return View(pNewAboutView);
            }
        }

        // GET: AdminAbout/Delete/5
        [HasRule(RuleId = ("DELETE_ABOUT"))]
        public ActionResult Delete(int id)
        {
            return View(new AboutModel().GetAboutById(id));
        }

        // POST: AdminAbout/Delete/5
        [HttpPost]
        [HasRule(RuleId = ("DELETE_ABOUT"))]
        public ActionResult Delete(int id, About pNewAbout)
        {
            try
            {
                // TODO: Add delete logic here
                var check = new AboutModel().Delete(id);
                if(check==true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pNewAbout);
                }
            }
            catch
            {
                return View(pNewAbout);
            }
        }
    }
}

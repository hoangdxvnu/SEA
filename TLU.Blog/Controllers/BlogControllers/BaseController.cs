﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataViews;

namespace TLU.Blog.Controllers
{
    public class BaseController : Controller
    {

        public ThangLongEntities _db = new ThangLongEntities();

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            // If check ViewBag.Navigation is null call back. Caching ViewBag.Navigation. Not using Redis cache. Recommend using Solir solution
            ViewBag.Navigation = _db.Navigations.Where(x=>x.LangId==Blog.Helpers.BlogLang.CurrentLang).Where(x=>x.IsActive==true).OrderBy(x => x.OrderDisplay).ToList();

            ViewBag.Sologan = _db.Configs.Where(x=>x.LangId==BlogLang.CurrentLang).Where(x => x.Code == "Banner").ToList();
         
            if(SessionHelper.GetSession(Constant.SESSION_USER)!=null)
            {
                UserSession User = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
                ViewBag.Profile = User;
            } 
            base.Initialize(requestContext);
        }


        public string GetCurrentAction
        {
            get
            {
                var currenController = ControllerContext.RouteData;

                var stringBulder = new StringBuilder();

                stringBulder.AppendLine(string.Format("{0}/{1}", currenController.GetRequiredString("controller"), currenController.GetRequiredString("action")));

                return stringBulder.ToString();
            }

            set
            {
                GetCurrentAction = value;
            }
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.AdminControllers;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminHistoryController : AdminBaseController
    {
        // GET: AdminHistory
        [HasRule(RuleId = "VIEW_HISTORY")]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new HistoryModel().GetPageListHistory(Page,PageSize));
        }

        // GET: AdminHistory/Details/5
        [HasRule(RuleId = "DETAIL_HISTORY")]
        public ActionResult Details(int id)
        {
            return View(new HistoryModel().GetHistoryById(id));
        }
        


    }
}

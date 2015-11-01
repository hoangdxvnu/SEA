using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.AdminControllers
{
    public class AdminFeelBackController : AdminBaseController
    {
        //
        // GET: /AdminFeelBack/
        [HasRule(RuleId = "VIEW_FEELBACK")]
        public ActionResult Index(int Page = 1,int PageSize=10)
        {
            return View(new FeelBackModel().GetPageListFeelBack(Page,PageSize));
        }
        [HasRule(RuleId = "DETAIL_FEELBACK")]
        public ActionResult Details(int id)
        {
            new FeelBackModel().CheckFeedBack(id);
            return View(new FeelBackModel().GetFeelBackById(id));
        }
        [HttpGet]
        [HasRule(RuleId = "DELETE_FEELBACK")]
        public ActionResult Delete(int id)
        {
            return View(new FeelBackModel().GetFeelBackById(id));
        }
        [HttpPost]
        [HasRule(RuleId = "DELETE_FEELBACK")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                new FeelBackModel().Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
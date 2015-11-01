using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.AdminControllers;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminConfigsController : AdminBaseController
    {
        // GET: AdminConfigs
        [HasRule(RuleId = "VIEW_CONFIG")]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new ConfigModel().GetPageListConfig(Page,PageSize));
        }

        // GET: AdminConfigs/Details/5
        [HasRule(RuleId = "DETAIL_CONFIG")]
        public ActionResult Details(int id)
        {
            return View(new ConfigModel().GetConfigById(id));
        }

        // GET: AdminConfigs/Create
        [HasRule(RuleId = "CREATE_CONFIG")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminConfigs/Create
        [HttpPost]
        [HasRule(RuleId = "CREATE_CONFIG")]
        public ActionResult Create(Config pNewConfig,string Lang)
        {
            try
            {
                // TODO: Add insert logic here
                if (Lang == "Tiếng Việt")
                    pNewConfig.LangId = 0;
                else
                    pNewConfig.LangId = 1;
                var check = new ConfigModel().Create(pNewConfig);
                if (check)
                    return RedirectToAction("Index");
                else
                    return View(pNewConfig);
            }
            catch
            {
                return View(pNewConfig);
            }
        }

        // GET: AdminConfigs/Edit/5
        [HasRule(RuleId = "EDIT_CONFIG")]
        public ActionResult Edit(int id)
        {
            return View(new ConfigModel().GetConfigById(id));
        }

        // POST: AdminConfigs/Edit/5
        [HttpPost]
        [HasRule(RuleId = "EDIT_CONFIG")]
        public ActionResult Edit(int id, Config pNewConfig,string Lang)
        {
            try
            {
                // TODO: Add update logic here
                if (Lang == "Tiếng Việt")
                    pNewConfig.LangId = 0;
                else
                    pNewConfig.LangId = 1;
                var check = new ConfigModel().Edit(id,pNewConfig);
                if (check)
                    return RedirectToAction("Index");
                else
                    return View(pNewConfig);
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminConfigs/Delete/5
        [HasRule(RuleId = "DELETE_CONFIG")]
        public ActionResult Delete(int id)
        {
            return View(new ConfigModel().GetConfigById(id));
        }

        // POST: AdminConfigs/Delete/5
        [HttpPost]
        [HasRule(RuleId = "DELETE_CONFIG")]
        public ActionResult Delete(int id, Config pNewConfig)
        {
            try
            {
                // TODO: Add delete logic here
                var check = new ConfigModel().Remove(id);
                if (check)
                    return RedirectToAction("Index");
                else
                    return View(pNewConfig);
            }
            catch
            {
                return View();
            }
        }
    }
}

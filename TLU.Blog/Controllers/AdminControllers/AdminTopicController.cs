using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataViews;
using TLU.Blog.Helpers;
using TLU.Blog.AdminControllers;
namespace TLU.Blog.Controllers.AdminControllers
{
    public class AdminTopicController : AdminBaseController
    {
        private UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
        // GET: AdminTopic
        [HasRule(RuleId = "VIEW_TOPIC")]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new TopicModel().GetPageListTopic(Page,PageSize));
        }

        // GET: AdminTopic/Details/5
        [HasRule(RuleId = "DETAIL_TOPIC")]
        public ActionResult Details(int id)
        {
            return View(new TopicModel().GetTopicById(id));
        }

        // GET: AdminTopic/Create
        [HasRule(RuleId = "CREATE_TOPIC")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTopic/Create
        [HttpPost]
        [HasRule(RuleId = "CREATE_TOPIC")]
        public ActionResult Create(TopicView pNewTopicView)
        {
            var pNewTopic = new Topic();
            try
            {
                // TODO: Add insert logic here
                pNewTopic.ImageId = pNewTopicView.ImageId;
                pNewTopic.Name = pNewTopicView.Name;
                pNewTopic.Code = pNewTopicView.Code;
                pNewTopic.Descrip = pNewTopicView.Descrip;
                pNewTopic.OrderDisplay = pNewTopicView.OrderDisplay;
                pNewTopic.TopicParentID = new TopicModel().GetIdByName(pNewTopicView.TopicParentID);
                if(pNewTopicView.LangId=="Tiếng Việt")
                {
                    pNewTopic.LangId = 0;
                }
                else
                {
                    pNewTopic.LangId = 1;
                }
                pNewTopic.CreatedBy = account.Id;
                pNewTopic.CreatedDate = DateTime.Now;
                pNewTopic.EditBy = account.Id;
                pNewTopic.EditDate = DateTime.Now;
                pNewTopic.IsActive = true;
                var check = new TopicModel().Create(pNewTopic);
                if(!check)
                {
                    return View(pNewTopicView);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pNewTopicView);
            }
        }

        // GET: AdminTopic/Edit/5
        [HasRule(RuleId = "EDIT_TOPIC")]
        public ActionResult Edit(int id)
        {
            var Object = new TopicModel().GetTopicById(id);
            var Result = new TopicView();
            Result.Name = Object.Name;
            Result.Code = Object.Code;
            Result.ImageId = Object.ImageId;
            Result.Descrip = Object.Descrip;
            Result.OrderDisplay = Object.OrderDisplay;
            Result.TopicParentID = new TopicModel().GetNameById(Object.TopicParentID);
            if(Object.LangId==0)
            {
                Result.LangId = "Tiếng Việt";
            }
            else
            {
                Result.LangId = "Tiếng Anh";
            }
            return View(Result);
        }

        // POST: AdminTopic/Edit/5
        [HttpPost]
        [HasRule(RuleId = "EDIT_TOPIC")]
        public ActionResult Edit(int id, TopicView pNewTopicView)
        {
            Topic pNewTopic = new Topic();
            try
            {
                // TODO: Add update logic here
                pNewTopic.ImageId = pNewTopicView.ImageId;
                
                pNewTopic.Name = pNewTopicView.Name;
                pNewTopic.Code = pNewTopicView.Code;
                pNewTopic.Descrip = pNewTopicView.Descrip;
                pNewTopic.OrderDisplay = pNewTopicView.OrderDisplay;
                pNewTopic.TopicParentID = new TopicModel().GetIdByName(pNewTopicView.TopicParentID);
                if (pNewTopicView.LangId == "Tiếng Việt")
                {
                    pNewTopic.LangId = 0;
                }
                else
                {
                    pNewTopic.LangId = 1;
                }
                pNewTopic.CreatedBy = account.Id;
                pNewTopic.CreatedDate = DateTime.Now;
                pNewTopic.EditBy = account.Id;
                pNewTopic.EditDate = DateTime.Now;
                pNewTopic.IsActive = true;
                var check = new TopicModel().Edits(id,pNewTopic);
                if (!check)
                {
                    return View(pNewTopicView);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new TopicModel().GetTopicById(id));
            }
        }

        // GET: AdminTopic/Delete/5
        [HasRule(RuleId = "DELETE_TOPIC")]
        public ActionResult Delete(int id)
        {
            return View(new TopicModel().GetTopicById(id));
        }

        // POST: AdminTopic/Delete/5
        [HttpPost]
        [HasRule(RuleId = "DELETE_TOPIC")]
        public ActionResult Delete(int id, Topic pNewTopic)
        {
            try
            {
                // TODO: Add delete logic here
                var check = new TopicModel().Delete(id);
                if(check)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(pNewTopic);
                }
                
            }
            catch
            {
                return View(pNewTopic);
            }
        }
    }
}

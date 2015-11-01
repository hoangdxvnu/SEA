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
    public class AdminPostsController : AdminBaseController
    {
        private UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
        // GET: AdminPosts
        [HasRule(RuleId = "VIEW_POST")]
        public ActionResult Index(int Page=1,int PageSize=10)
        {
            return View(new PostModel().GetPageListOrderByTime(Page,PageSize));
        }

        // GET: AdminPosts/Details/5
        [HasRule(RuleId = "DETAIL_POST")]
        public ActionResult Details(int id=5)
        {
            
            return View(new PostModel().GetPostById(id));
        }

        // GET: AdminPosts/Create
        [HasRule(RuleId = "CREATE_POST")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPosts/Create
        [HttpPost]
        [HasRule(RuleId = "CREATE_POST")]
        public ActionResult Create(PostView NewPostView)
        {
            Post pNewPost = new Post();
            try
            {
                // TODO: Add insert logic here
                pNewPost.Avatar = NewPostView.Avatar;
                pNewPost.AccountID = account.Id;
                pNewPost.PostContent = NewPostView.pContent;
                pNewPost.TopicID = new TopicModel().GetIdByName(NewPostView.pNameTopic);
                pNewPost.Like = 0;
                pNewPost.Dislike = 0;
                pNewPost.Descrip = NewPostView.pDescrip;
                pNewPost.PostDate = DateTime.Now;
                pNewPost.IsActive = true;
                pNewPost.LangId = 0;
                var check = new PostModel().Create(pNewPost);
                if(check==true)
                {
                    return RedirectToAction("Index");
                }
                return View(NewPostView);
            }
            catch
            {
                return View(NewPostView);
            }
        }

        // GET: AdminPosts/Edit/5
        [HasRule(RuleId = "EDIT_POST")]
        public ActionResult Edit(int id)
        {
            Post pNewPost = new PostModel().GetPostById(id);
            PostView pNewPostView = new PostView();
            pNewPostView.pDescrip = pNewPost.Descrip;
            pNewPostView.pNameTopic = new TopicModel().GetNameById(pNewPost.TopicID);
            pNewPostView.pContent = pNewPost.PostContent;
            pNewPostView.Avatar = pNewPost.Avatar;
            return View(pNewPostView);
        }

        // POST: AdminPosts/Edit/5
        [HttpPost]
        [HasRule(RuleId = "EDIT_POST")]
        public ActionResult Edit(int id, PostView NewPostView)
        {
            Post pNewPost = new Post();
            try
            {
                // TODO: Add insert logic here
                pNewPost.Avatar = NewPostView.Avatar;
                pNewPost.PostContent = NewPostView.pContent;
                pNewPost.TopicID = new TopicModel().GetIdByName(NewPostView.pNameTopic);
                pNewPost.Descrip = NewPostView.pDescrip;
                pNewPost.IsActive = true;
                var check = new PostModel().Edit(id, pNewPost);
                if (check)
                    return RedirectToAction("Index");
                else
                    return View(NewPostView);
            }
            catch
            {
                return View(NewPostView);
            }
        }

        // GET: AdminPosts/Delete/5
        [HasRule(RuleId = "DELETE_POST")]
        public ActionResult Delete(int id = 5)
        {
            
            return View(new PostModel().GetPostById(id));
        }

        // POST: AdminPosts/Delete/5
        [HttpPost]
        [HasRule(RuleId = "DELETE_POST")]
        public ActionResult Delete(int id, PostView NewPostView)
        {
            try
            {
                // TODO: Add delete logic here
                if(new PostModel().Remove(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(new PostModel().GetPostById(id));
                }
            }
            catch
            {
                return View(new PostModel().GetPostById(id));
            }
        }
    }
}

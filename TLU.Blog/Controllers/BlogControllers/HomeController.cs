using System;
using System.Collections.Generic;
using System.Linq;
using TLU.Blog.Models.DataBase;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataViews;
using TLU.Blog.Models.DataModels;
namespace TLU.Blog.Controllers
{
    public class HomeController : BaseController
    {
        private UserSession account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;

        public ActionResult Index()
        {
            ViewBag.listHot = new PostModel().GetListTopHotPost(2);
            ViewBag.listNew = new PostModel().GetListTopNewPost(4);
            return View();
        }

        public ActionResult About(int id=3)
        {
            ViewBag.Message = "Your application description page.";
            return View(new AboutModel().GetAboutById(id));
        }

        public ActionResult New()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Answer(int id=11,int Page=1,int PageSize=3)
        {
            ViewBag.ListTopic = new TopicModel().GetListTopicParentOrderByPosition();
            ViewBag.Type = new TopicModel().GetTopicById(id);
            if (id==11)
            {
                return View(new PostModel().GetPageListOrderByLike(Page, PageSize));
            }
            else if(id==10)
            {
                return View(new PostModel().GetPageListOrderByTimeIsActive(Page, PageSize));
            }
            return View(new PostModel().GetPageListByIdTopic(id,Page,PageSize));
        }

        public ActionResult ChangeLanguage(string Id)
        {
            // vi
            TLUResourceManager.SetLanguage(Id);

            BlogLang.SetLanguage(Id);

            return RedirectToAction("Index");

        }

        [HasRule(RuleId=("CREATE_POST"))]
        public ActionResult NewPost()
        {
            if (account == null)
                return RedirectToAction("Index", "Error");
            ViewBag.ListTopic = new TopicModel().GetListTopic();
            ViewBag.Position = 0;
            return View();
        }
        [HttpPost]
        [HasRule(RuleId = ("CREATE_POST"))]
        public ActionResult NewPost(PostView NewPostView)
        {
            if(account==null)
                return RedirectToAction("Index","Error");
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
                if (NewPostView.pDescrip == "" || NewPostView.Avatar == ""||NewPostView.pContent=="")
                {
                    ViewBag.ListTopic = new TopicModel().GetListTopic();
                }
                pNewPost.PostDate = DateTime.Now;
                pNewPost.IsActive = true;
                pNewPost.LangId = 0;
                var check = new PostModel().Create(pNewPost);
                if (check == true)
                {
                    return RedirectToAction("Index");
                }
                ViewBag.ListTopic = new TopicModel().GetListTopic();
                return View(NewPostView);
            }
            catch
            {
                ViewBag.ListTopic = new TopicModel().GetListTopic();
                return View(NewPostView);
            }
        }

        public ActionResult Post(int id)
        {
            ViewBag.ListTopic = new TopicModel().GetListTopicParentOrderByPosition();
            var result = new PostModel().GetPostById(id);
            return View(result);
        }

        [HasRule(RuleId = "ADD_LIKE")]
        public ActionResult ViewLike(int pId)
        {
            new VotesModel().ChangeLike(account.Id, pId);
            var result = new PostModel().GetPostById(pId);
            return View(result);
        }
        [HttpPost]
        [HasRule(RuleId = "ADD_COMMENT")]
        public ActionResult AddComment(string pContent, int pPostId)
        {
            var Object = new Comment();
            Object.CommentDate = DateTime.Now;
            Object.AccountID = account.Id;
            Object.ParentId = 0;
            Object.CommentLike = 0;
            Object.CommentContent = pContent;
            Object.IsActive = true;
            Object.LangId = 0;
            Object.PostID = pPostId;
            new CommentModel().Create(Object);
            ViewBag.PostID = pPostId;
            return View();
        }
        [HttpPost]
        [HasRule(RuleId="ADD_REPLY")]
        public ActionResult AddReply(string pReplyContent,int pCommentId)
        {
            var Object = new Comment();
            Object.CommentDate = DateTime.Now;
            Object.AccountID = account.Id;
            Object.ParentId = pCommentId;
            Object.CommentLike = 0;
            Object.CommentContent = pReplyContent;
            Object.IsActive = true;
            Object.LangId = 0;
            Object.PostID = new CommentModel().GetPostIdByCommnetParentId(pCommentId);
            new CommentModel().Create(Object);
            ViewBag.ID = pCommentId;
            return View();
        }
        [HasRule(RuleId = "REMOVE_COMMENT")]
        public void RemoveComment(int pId)
        {
            new CommentModel().Remove(pId);
        }

        public int CountComment(int pPostId)
        {
            return new CommentModel().GetCountComment(pPostId);
        }

        public ActionResult AutoCountLike(int pPostId)
        {
            var result = new PostModel().GetPostById(pPostId);
            return View(result);
        }

        public ActionResult AutoListComment(int pPostId)
        {
            ViewBag.PostId = pPostId;
            return View();
        }

        public ActionResult LogOut()
        {
            SessionHelper.Remove(Constant.SESSION_USER);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditComment(int pId)
        {
            ViewBag.Content = new CommentModel().GetContentPostById(pId);
            ViewBag.Id = pId;
            return View();
        }
        [HttpPost]
        public ActionResult EditComment(int pId, string pContent)
        {
            new CommentModel().SetContentPostById(pId, pContent);
            return RedirectToAction("ResultEditComment", "Home", new { id = pId});
        }
        public ActionResult ResultEditComment(int id)
        {
            ViewBag.Result = new CommentModel().GetContentPostById(id);
            return View();
        }
    }
}
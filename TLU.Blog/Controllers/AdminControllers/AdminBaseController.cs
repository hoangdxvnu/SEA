using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Helpers;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;
namespace TLU.Blog.AdminControllers
{
    public class AdminBaseController : Controller
    {
        [HasRule(RuleId="a")]
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Checking token and Username
            if(HttpContext.Session[Constant.SESSION_USER]==null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary((new { controller = "AdminLogIn", action = "logIn" })));
            }
            base.OnActionExecuting(filterContext);
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            // Using caching
            var account = SessionHelper.GetSession(Constant.SESSION_USER) as UserSession;
            var Profile = new AccountModel().GetProfile(account.Id);
            ViewBag.Profile = Profile;
            base.Initialize(requestContext);
        }
    }
}
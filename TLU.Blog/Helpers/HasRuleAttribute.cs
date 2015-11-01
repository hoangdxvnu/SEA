using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLU.Blog.Models.DataModels;
using TLU.Blog.Models.DataViews;
namespace TLU.Blog.Helpers
{
    public class HasRuleAttribute:AuthorizeAttribute
    {
        public string RuleId { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var Account = (UserSession)HttpContext.Current.Session[ Constant.SESSION_USER];
            if (Account == null)
                return false;
            if (Account.Level == Constant.ADMIN)
                return true;
            List<string> PowerOfLevel = GetRuleByUserName(Account.UserName);
            if (PowerOfLevel.Contains(RuleId))
                return true;
            else
                return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName="~/Views/Shared/Error.cshtml"
            };
        }
        private List<string> GetRuleByUserName(string UserName)
        {
            return (List<string>)HttpContext.Current.Session[Constant.SESSION_RULE];
        }

    }
}
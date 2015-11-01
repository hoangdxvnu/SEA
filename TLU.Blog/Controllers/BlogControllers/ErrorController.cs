using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TLU.Blog.Controllers.BlogControllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Index(int id)
        {

            return View(id);
        }
    }
}
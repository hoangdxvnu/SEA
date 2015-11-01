using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLU.Blog.Helpers
{
    public class BlogString
    {
        public string GetStringHasLength(int Length,String Content)
        {
            string  Result = "";
            if (Length > Content.Length)
                return Content;
            else
            {
                Result = Content.Substring(0,50);
                Result += " ...";
                return Result;
            }
            
        }
    }
}
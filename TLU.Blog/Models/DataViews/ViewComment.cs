using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLU.Blog.Models.DataViews
{
    public class ViewComment
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string CreateBy { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
    }
}
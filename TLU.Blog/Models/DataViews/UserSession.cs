using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TLU.Blog.Models.DataViews
{
    public class UserSession
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Level { get; set; }
        public string FirstName { get; set; }
    }
}
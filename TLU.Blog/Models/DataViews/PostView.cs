using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataViews
{
    public class PostView
    {
        [Required]
        public string pNameTopic { get; set; }
        [Required]
        [StringLength(2000)]
        public string pDescrip { get; set; }
        [Required]
        [AllowHtml]
        public string pContent { get; set; }
        [Required]
        public string Avatar { get; set; }
    }
}

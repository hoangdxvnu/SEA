using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TLU.Blog.Models.DataViews
{
    public class AboutView
    {
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }
        [Required]
        [StringLength(4000)]
        public string Descritp { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        public string Image { get; set; }
        public Nullable<int> OrderDisplay { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [Required]
        public string LangId { get; set; }
    }
}

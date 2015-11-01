using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLU.Blog.Models.DataViews
{
    public class TopicView
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Tên topic")]
        public string Name { get; set; }
        [Display(Name = "Mã topic")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "Ảnh đại diện")]
        public string ImageId { get; set; }
        [Required]
        [Display(Name = "Miêu tả")]
        public string Descrip { get; set; }
        [Required]
        [Display(Name = "Vị trí hien thị")]
        public Nullable<int> OrderDisplay { get; set; }
        [Required]
        [Display(Name = "Topic cha")]
        public string TopicParentID { get; set; }
        [Required]
        [Display(Name = "Ngôn Ngữ")]
        public string LangId { get; set; }
    }
}

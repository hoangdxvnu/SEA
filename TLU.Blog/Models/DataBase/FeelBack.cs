//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TLU.Blog.Models.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeelBack
    {
        public int ID { get; set; }
        public string Descript { get; set; }
        public string Code { get; set; }
        public Nullable<int> Sender { get; set; }
        public string Content { get; set; }
        public System.DateTime SendDate { get; set; }
        public Nullable<bool> Check { get; set; }
        public Nullable<byte> LangId { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
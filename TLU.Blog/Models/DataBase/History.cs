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
    
    public partial class History
    {
        public int ID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public string Descrip { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<byte> LangId { get; set; }
        public Nullable<bool> Check { get; set; }
        public Nullable<int> IpAddress { get; set; }
    
        public virtual Account Account { get; set; }
    }
}

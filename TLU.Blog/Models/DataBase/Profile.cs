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
    
    public partial class Profile
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Nullable<byte> LangId { get; set; }
        public string HomeTown { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Job { get; set; }
        public string Hoppy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
    
        public virtual Account Account { get; set; }
    }
}

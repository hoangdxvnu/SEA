using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Services
{
    
    public class Factory
    {
        ThangLongEntities dbContext = null;

        public void SaveCommemntRealtime(Comment modelData)
        {
            dbContext = new ThangLongEntities();

            

            dbContext.Comments.Add(modelData);
        }
    }
}
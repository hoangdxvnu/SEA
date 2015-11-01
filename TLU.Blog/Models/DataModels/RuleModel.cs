using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class RuleModel
    {
        ThangLongEntities _db;
        public RuleModel()
        {
            _db = new ThangLongEntities();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class FeelBackModel
    {
        ThangLongEntities _db;
        public FeelBackModel()
        {
            _db = new ThangLongEntities();
        }
        public FeelBack GetFeelBackById(int pFeelBackId)
        {
            return _db.FeelBacks.Find(pFeelBackId);
        }

        public PagedList<FeelBack> GetPageListFeelBack(int pPage,int pPageSize)
        {
            var result = _db.FeelBacks.OrderBy(x => x.Check).OrderByDescending(x=>x.SendDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<FeelBack>;
        }

        public string GetNameAccountById(int? pAccountId)
        {
            string str;
            var Object = _db.Accounts.Find(pAccountId);
            if (Object.Profile.LangId == 0)
            {
                str = Object.Profile.SurName + ' ' + Object.Profile.FirstName;
            }
            else
            {
                str = Object.Profile.FirstName + ' ' + Object.Profile.SurName;
            }
            return str;
        }

        public bool Delete(int pId)
        {
            try
            {
                _db.FeelBacks.Remove(_db.FeelBacks.Find(pId));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CountNotCheck()
        {
            return _db.FeelBacks.Where(x => x.Check == false).Count();
        }

        public PagedList<FeelBack> GetListFeedBackNotCheck()
        {
            int pPage = 1, pPageSize = 5;
            var Result = _db.FeelBacks.OrderByDescending(x => x.Check.Value).OrderByDescending(x => x.SendDate).ToPagedList(pPage, pPageSize) as PagedList<FeelBack>;
            return Result;
        }

        public void CheckFeedBack(int pId)
        {
            _db.FeelBacks.Find(pId).Check = true;
            _db.SaveChanges();
        }
    }
}

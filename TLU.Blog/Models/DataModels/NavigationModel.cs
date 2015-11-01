using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class NavigationModel
    {
        ThangLongEntities _db;
        public NavigationModel()
        {
            _db = new ThangLongEntities();
        }
        public bool Create(Navigation pNewNavigation)
        {
            try
            {
                _db.Navigations.Add(pNewNavigation);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int pId,Navigation pNewNavigation)
        {
            try
            {
                var Object = _db.Navigations.Find(pId);
                Object.Name = pNewNavigation.Name;
                Object.Code = pNewNavigation.Code;
                Object.Icon = pNewNavigation.Icon;
                Object.Link = pNewNavigation.Link;
                Object.OrderDisplay = pNewNavigation.OrderDisplay;
                Object.CreatedBy = pNewNavigation.CreatedBy;
                Object.CreatedDate = pNewNavigation.CreatedDate;
                Object.EditBy = pNewNavigation.EditBy;
                Object.EditDate = pNewNavigation.EditDate;
                Object.IsActive = pNewNavigation.IsActive;
                Object.LangId = pNewNavigation.LangId;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangActive(int pId)
        {
            try {
                var Object = _db.Navigations.Find(pId);
                if (Object.IsActive == true)
                    Object.IsActive = false;
                else
                    Object.IsActive = true;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PagedList<Navigation> GetPageListNavigation(int pPage,int pPageSize)
        {
            var Object = _db.Navigations.OrderByDescending(x => x.ID).ToPagedList(pPage, pPageSize) as PagedList<Navigation>;
            return Object;
        }
        public Navigation GetNavigationById(int pId)
        {
            return _db.Navigations.Find(pId);
        }
        public bool Delete(int pId)
        {
            try
            {
                _db.Navigations.Remove(_db.Navigations.Find(pId));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class AboutModel
    {
        ThangLongEntities _db;
        public AboutModel()
        {
            _db = new ThangLongEntities();
        }
        public PagedList<About> GetPageListAboutIsActive(int pPage,int pPageSize)
        {
            var result = _db.Abouts.OrderByDescending(x => x.EditDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<About>;
        }
        public PagedList<About> GetPageListAbout(int pPage, int pPageSize)
        {
            var result = _db.Abouts.OrderByDescending(x => x.EditDate).ToPagedList(pPage, pPageSize);
            return result as PagedList<About>;
        }
        public bool Create(About pNewAbout)
        {
            try
            {
                _db.Abouts.Add(pNewAbout);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int pAboutId,About pNewAbout)
        {
            try
            {
                var Object = _db.Abouts.Find(pAboutId);
                Object.Image = pNewAbout.Image;
                Object.Content = pNewAbout.Content;
                Object.OrderDisplay = pNewAbout.OrderDisplay;
                Object.EditBy = pNewAbout.EditBy;
                Object.EditDate = pNewAbout.EditDate;
                Object.IsActive = pNewAbout.IsActive;
                Object.Descritp = pNewAbout.Descritp;
                Object.Name = pNewAbout.Name;
                Object.LangId = pNewAbout.LangId;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public About GetAboutById(int pAboutId)
        {
            return _db.Abouts.Find(pAboutId);
        }
        public void ChangeActive(int pAboutId)
        {
            var Object = _db.Abouts.Find(pAboutId);
            Object.IsActive = !Object.IsActive;
            _db.SaveChanges();
        }
        public bool Delete(int pAboutId)
        {
            try
            {
                _db.Abouts.Remove(_db.Abouts.Find(pAboutId));
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

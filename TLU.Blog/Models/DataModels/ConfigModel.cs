using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataViews;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class ConfigModel
    {
        ThangLongEntities _db;
        public ConfigModel()
        {
            _db = new ThangLongEntities();
        }
        public PagedList<Config> GetPageListConfig(int pPage,int pPageSize)
        {
            return _db.Configs.OrderBy(x => x.Id).ToPagedList(pPage, pPageSize) as PagedList<Config>;
        }
        public bool Create(Config pNewConfig)
        {
            try
            {
                _db.Configs.Add(pNewConfig);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int pId,Config pNewConfig)
        {
            try
            {
                var Object = _db.Configs.Find(pId);
                Object.Code = pNewConfig.Code;
                Object.Name = pNewConfig.Name;
                Object.Order = pNewConfig.Order;
                Object.IsActive = pNewConfig.IsActive;
                Object.LangId = pNewConfig.LangId;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(int pId)
        {
            try
            {
                _db.Configs.Remove(_db.Configs.Find(pId));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Config GetConfigById(int pId)
        {
            return _db.Configs.Find(pId);
        }
    }
}

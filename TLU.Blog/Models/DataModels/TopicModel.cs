using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using PagedList;
namespace TLU.Blog.Models.DataModels
{
    public class TopicModel
    {
        ThangLongEntities _db;
        public TopicModel()
        {
            _db = new ThangLongEntities();
        }
        public Topic GetTopicById(int pId)
        {
            return _db.Topics.Find(pId);
        }
        public PagedList<Topic> GetPageListTopic(int pPage,int pPageSize)
        {
            return _db.Topics.OrderByDescending(x => x.EditDate).ToPagedList(pPage, pPageSize) as PagedList<Topic>;
        }
        public List<Topic> GetListTopicByParentId(int pParentId)
        {
            return _db.Topics.Where(x => x.TopicParentID == pParentId).ToList();
        }
        public List<Topic> GetListTopicParent()
        {
            return _db.Topics.Where(x => x.TopicParentID == 0).ToList();
        }
        public List<Topic> GetListTopicParentOrderByPosition()
        {
            return _db.Topics.Where(x => x.TopicParentID == 0).OrderBy(x=>x.OrderDisplay).ToList();
        }
        public List<Topic> GetListTopicDifferent(int pId)
        {
            return _db.Topics.Where(x => x.ID != pId).ToList();
        }
        public List<string> GetListNameTopicDifferent(int pId)
        {
            List<string> result = new List<string>();
            result.Add("Không");
            var Object = GetListTopicDifferent(pId);
            foreach (var item in Object)
            {
                result.Add(item.Name);
            }
            return result;
        }
        public List<string> GetListNameTopic()
        {
            var Object= _db.Topics.Where(x=>x.IsActive==true).ToList();
            List<string> result= new List<string>();
            result.Add("Không");
            foreach (var item in Object)
            {
                result.Add(item.Name);
            }
            return result;
        }
        public int? GetIdByName(string pName)
        {
            var result = _db.Topics.Where(x => x.Name == pName).SingleOrDefault();
            if (result == null)
                return 0;
            else
                return result.ID;
        }
        public string GetNameById(int? pId)
        {
            var Object = _db.Topics.Find(pId);
            if (Object == null)
                return "Không Có";
            return Object.Name;
        }
        public List<Topic> GetListTopic()
        {
            return _db.Topics.Where(x=>x.IsActive==true).ToList();
        }
        public bool Create (Topic pNewTopic)
        {
            try
            {
                _db.Topics.Add(pNewTopic);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edits (int pId,Topic pNewTopic)
        {
            try
            {
                var Object = _db.Topics.Find(pId);
                Object.Name = pNewTopic.Name;
                Object.Code = pNewTopic.Code;
                Object.ImageId = pNewTopic.ImageId;
                Object.Descrip = pNewTopic.Descrip;
                Object.OrderDisplay = pNewTopic.OrderDisplay;
                Object.TopicParentID = pNewTopic.TopicParentID;
                Object.EditBy = pNewTopic.EditBy;
                Object.EditDate = pNewTopic.EditDate;
                Object.IsActive = pNewTopic.IsActive;
                Object.LangId = pNewTopic.LangId;
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
                _db.Topics.Find(pId).IsActive = false;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int pId)
        {
            try
            {
                _db.Topics.Remove(_db.Topics.Find(pId));
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

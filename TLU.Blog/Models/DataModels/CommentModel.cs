﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
namespace TLU.Blog.Models.DataModels
{
    public class CommentModel
    {
        ThangLongEntities _db;
        public CommentModel()
        {
            _db = new ThangLongEntities();
        }
        public bool Create(Comment pNewComment)
        {
            try
            {
                _db.Comments.Add(pNewComment);
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
                if (_db.Comments.Find(pId).ParentId == 0)
                {
                    var data = _db.Comments.Where(x => x.ParentId == pId);
                    foreach (var item in data)
                    {
                        _db.Comments.Remove(item);
                    }
                }
                _db.Comments.Remove(_db.Comments.Find(pId));
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditContent(int pId,string Content)
        {
            try
            {
                _db.Comments.Find(pId).CommentContent = Content;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(int pId,Comment pNewComment)
        {
            try
            {
                var Object = _db.Comments.Find(pId);
                Object.CommentDate = pNewComment.CommentDate;
                Object.AccountID = pNewComment.AccountID;
                Object.PostID = pNewComment.PostID;
                Object.CommentLike = pNewComment.CommentLike;
                Object.CommentContent = pNewComment.CommentContent;
                Object.IsActive = pNewComment.IsActive;
                Object.LangId = pNewComment.LangId;
                Object.Permission = pNewComment.Permission;
                Object.ParentId = pNewComment.ParentId;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Comment> GetCommentOrderByDate(int pPostId)
        {
            return _db.Comments.Where(x=>x.PostID==pPostId).Where(x=>x.ParentId==0).Where(x => x.IsActive == true).OrderByDescending(x => x.CommentDate).ToList();
        }
        public int GetCountComment(int pPostId)
        {
            return _db.Comments.Where(x => x.PostID == pPostId).Where(x => x.IsActive == true).Where(x=>x.ParentId==0).ToList().Count;
        }
        public int GetPostIdByCommnetParentId(int pId)
        {
            return _db.Comments.Find(pId).PostID;
        }
        public List<Comment> GetList(int pParentCommentId)
        {
            var result = _db.Comments.Where(x => x.ParentId == pParentCommentId).Where(x=>x.IsActive==true).OrderByDescending(x=>x.CommentDate).ToList();
            return result;
        }
        public string GetContentPostById(int Id)
        {
            return _db.Comments.Find(Id).CommentContent;
        }
        public void SetContentPostById(int Id,string Content)
        {
            _db.Comments.Find(Id).CommentContent = Content;
            _db.SaveChanges();
        }
    }
}

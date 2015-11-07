using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace TLU.Blog
{
    public class RealtimeDataHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void AddComment(string PostId,string Content,string Parent)
        {
            int Count = 5;
            string Avatar = "a";
            string Name = "b";
            var Time = DateTime.Now;
            Clients.All.addComment(PostId, Content,Count,Avatar,Name,Time);
        }
        public void AddReply(string PostId, string Content, string Parent)
        {
            int Count = 5;
            string Avatar = "a";
            string Name = "b";
            var Time = DateTime.Now;
            Clients.All.addReply(PostId, Content, Parent, Count, Avatar, Name, Time);
        }
        public void EditComment(string PostId, string Content, string CommentId)
        {
            Clients.All.editComment(PostId, Content, CommentId);
        }
        public void Remove(string PostId,string CommentId)
        {
            Clients.All.removeComment(PostId, CommentId);
        }
        public void ChangeLike(string PostId)
        {
            int CountLike = 0;
            Clients.All.ChangeLike(PostId, CountLike);
        }
    }
}
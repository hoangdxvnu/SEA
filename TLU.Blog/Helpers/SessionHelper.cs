using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TLU.Blog.Helpers
{
    public class SessionHelper
    {
        public static Object GetSession(string Key)
        {
            if (HttpContext.Current.Session[Key] == null)
                return null;
            return HttpContext.Current.Session[Key];
        }
        public static void SetSesstion(string Key,Object Object)
        {
            if(HttpContext.Current.Session[Key]==null)
            {
                HttpContext.Current.Session.Add(Key, Object);
            }
            else
            {
                HttpContext.Current.Session[Key] = Object;
            }
        }
        public static bool Remove(string Key)
        {
            try
            {
                HttpContext.Current.Session.Remove(Key);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
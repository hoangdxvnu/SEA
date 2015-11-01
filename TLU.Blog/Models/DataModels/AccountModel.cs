using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLU.Blog.Models.DataBase;
using TLU.Blog.Models.DataViews;
using PagedList;
using TLU.Blog.Helpers;
using System.Data.Entity.Core.Objects;
using System.Security;
using TLU.Blog.Security;
namespace TLU.Blog.Models.DataModels
{
    public class AccountModel
    {
        ThangLongEntities _db;
        public AccountModel()
        {
            _db = new ThangLongEntities();
        }
        public string GetNameById(int pId)
        {
            string str;
            var Object = _db.Accounts.Find(pId);
            if(Object.Profile.LangId == 0)
            {
                str = Object.Profile.SurName + ' ' + Object.Profile.FirstName;
            }
            else
            {
                str = Object.Profile.FirstName + ' ' + Object.Profile.SurName;
            }
            return str;
        }
        public Profile GetProfileById(int pAccountId)
        {
            return _db.Accounts.Find(pAccountId).Profile;
        }
        public List<History> GetHistoryById(int pAccountId)
        {
            return _db.Accounts.Find(pAccountId).Histories.ToList();
        }
        public void CreateAccount (Account Data)
        {
            Data.CreatedDate = DateTime.Now;
            _db.Accounts.Add(Data);
            _db.SaveChanges();
        }
        public void CreateProfile(Profile Data)
        {
            _db.Profiles.Add(Data);
            _db.SaveChanges();
        }
        //-1 UserName=null,-2 PassWord=null,0 tài khoản không tồn tại,1 sai password,2 không có quyền,3 đang nhập thành công
        public int LogIn(User pAccountAdmin,bool LoginAdmin=false)
        {
            if (pAccountAdmin.UserName == null || pAccountAdmin.UserName == "")
                return -1;
            else if (pAccountAdmin.Password == null || pAccountAdmin.Password == "")
                return -2;
            else
            {
                var data = _db.Accounts.SingleOrDefault(x => x.UserName == pAccountAdmin.UserName);
                if (data == null)
                    return 0;
                else
                {
                    if (data.Password != pAccountAdmin.Password)
                        return 1;
                    else
                    {
                        if (LoginAdmin == true)
                        {
                            if (data.Level != Constant.ADMIN && data.Level != Constant.MOD)
                                return 2;
                            else
                                return 3;
                        }
                        else
                            return 3;
                    }
                }
            }
        }
        public PagedList<Account> GetPageListAccount(int pPage,int pPageSize)
        {
            return _db.Accounts.OrderByDescending(x => x.Histories.Count()).ToPagedList(pPage, pPageSize) as PagedList<Account>;
        }
        public List<string> GetListRule(string UserName)
        {
            var data = _db.Accounts.SingleOrDefault(x => x.UserName == UserName);
            if (data == null)
                return null;
            else
            {
                return data.Level1.Rules.ToList().Select(x => x.ID).ToList();
            }
        }
        public UserSession GetUserSession(string UserName)
        {

            var data = _db.Accounts.SingleOrDefault(x => x.UserName == UserName);
            UserSession result = new UserSession();
            result.Id = data.ID;
            result.UserName = data.UserName;
            result.Level = data.Level;
            result.FirstName = data.Profile.FirstName;
            result.Token = GetTokenSession(data.ID);
            return result;
        }

        public SecureString GetTokenSession(int Id)
        {
            var secruString = new SecureString();
            

            var generalValue = _db.Database.SqlQuery<string>(string.Format("SELECT dbo.TLU_sys_GenerateToKen({0})", Id.ToString())).FirstOrDefault();

            secruString = TLUSecureString.convertToSecureString(generalValue.ToString());

            return secruString;
        }
        public string GetUserName(int? Id)
        {
            if (Id == null || Id == 0)
                return "";
            return _db.Accounts.Find(Id).UserName;
        }
        public void EditPassword(int Id,string  Password)
        {
            var Account = _db.Accounts.Find(Id);
            Account.Password = Password;
            _db.SaveChanges();
        }
        public void EditProfile(int Id,Profile Data)
        {
            var Profile = _db.Profiles.Find(Id);
            _db.Entry(Profile).CurrentValues.SetValues(Data);
            _db.SaveChanges();
        }
        public Account GetAccount(int Id)
        {
            return _db.Accounts.Find(Id);
        }
        public Account GetAccount(string UserName)
        {
            return _db.Accounts.SingleOrDefault(x=>x.UserName==UserName);
        }
        public Profile GetProfile(int Id)
        {
            return _db.Profiles.Find(Id);
        }
        public List<string> GetListLevel()
        {
            return _db.Levels.ToList().Select(x=>x.ID).ToList();
        }
        public void Delete(int Id)
        {
            _db.Profiles.Remove(_db.Profiles.Find(Id));
            _db.Accounts.Remove(_db.Accounts.Find(Id));
            _db.SaveChanges();
        }
        public AccountView GetAccountViewToEditPassword(int Id)
        {
            var data= _db.Accounts.Find(Id);
            AccountView result = new AccountView();
            result.UserName = data.UserName;
            return result;
        }

    }
}

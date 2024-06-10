using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.DataModel.Models;
using GymManager.DataService;

namespace GymManager.Models
{
    public class UserEditModel
    {
        public List<PermissionListUser> _permissionsListUser;
        private readonly GymManagerContext _db = new();
        public int PasswordMinLenght => 8;
        public List<PermissionListUser> PermissionsListUser => GetPermissionListUser();

        public User User { get; private set; }

        public void ChangePassword(int userID, string password)
        {
            var db = new GymManagerContext();

            var user = (from u in db.Users
                where u.UserID == userID
                select u).FirstOrDefault();

            if(user == null)
            {
                return;
            }

            user.Password = Cryptography.MD5Hash(password);

            db.Update(user);

            db.SaveChanges<User>();
        }

        public bool CheckCorrectPassword(User user, string password)
        {
            if(user == null)
            {
                return false;
            }

            if(user.Password == Cryptography.MD5Hash(password))
            {
                return true;
            }

            return false;
        }

        public User GetUser(int userID)
        {
            var user = (from u in _db.Users
                where u.UserID == userID
                select u).FirstOrDefault();

            return user;
        }

        public void SaveChanges()
        {
            ProcessingPermission();

            _db.SaveChanges<User>();
        }

        public User SetEditObject(int userID)
        {
            if(User != null)
            {
                throw new Exception("Object is exist!");
            }

            User = _db.Users
                .Where(u => u.UserID == userID)
                .FirstOrDefault();

            User.DateModified = DateTime.Now;
            User.ModifiedBy = CurrentUser.User.UserID;

            return User;
        }

        public User SetNewObject()
        {
            if(User != null)
            {
                throw new Exception("Object is exist!");
            }

            User = new User
            {
                AddedBy = CurrentUser.User.UserID,
                DateAdded = DateTime.Now
            };

            _db.Add(User);

            return User;
        }

        private List<PermissionListUser> GetPermissionListUser()
        {
            if(_permissionsListUser == null)
            {
                _permissionsListUser = (from p in _db.PermissionsList
                        select new PermissionListUser
                            { PermissionListID = p.PermissionListID, Name = p.Name, IsGranted = false })
                    .OrderBy(p => p.PermissionListID).ToList();
            }

            if(User != null)
            {
                var permissions = _db.PermissionsUsers
                    .Where(u => u.UserID == User.UserID)
                    .ToList();

                foreach(var permission in _permissionsListUser)
                {
                    permission.IsGranted =
                        permissions.FirstOrDefault(p => p.PermissionListID == permission.PermissionListID) != null;
                }
            }

            return _permissionsListUser;
        }

        private void ProcessingPermission()
        {
            var permissionsUsers = _db.PermissionsUsers
                .Where(u => u.UserID == User.UserID)
                .ToList();

            foreach(var permissionListUser in _permissionsListUser)
            {
                var permissionUsers = permissionsUsers
                    .Where(p => p.PermissionListID == permissionListUser.PermissionListID)
                    .FirstOrDefault();

                if(permissionListUser.IsGranted && permissionUsers != null)
                {
                    continue;
                }

                if(permissionListUser.IsGranted && permissionUsers == null)
                {
                    _db.PermissionsUsers.Add(new PermissionUser
                    {
                        PermissionListID = permissionListUser.PermissionListID,
                        User = User,
                        DateAdded = DateTime.Now,
                        AddedBy = CurrentUser.User.UserID
                    });
                }
                else if(!permissionListUser.IsGranted && permissionUsers == null) { }
                else if(!permissionListUser.IsGranted && permissionUsers != null)
                {
                    _db.PermissionsUsers.Remove(permissionUsers);
                }
            }
        }
    }
}
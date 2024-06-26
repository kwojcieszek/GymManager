﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Models
{
    public class UsersModel
    {
        private List<User> _users;
        public bool OnlyActives { get; set; } = true;

        public List<User> Users => _users ?? GetUsers(OnlyActives);

        public void Delete(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("Element do usunięcia jest pusty.");
            }

            var db = new GymManagerContext();

            db.Users.Remove(user);

            db.SaveChanges<User>();
        }

        public List<User> GetUsers(bool onlyActives)
        {
            _users = new GymManagerContext()
                .Users
                .Where(m => m.IsAcive == true || m.IsAcive == onlyActives)
                .Include(u => u.AddedByUser)
                .Include(u => u.ModifiedByUser)
                .ToList();

            return _users;
        }
    }
}
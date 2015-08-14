using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Data;

namespace Web.Factory
{
    public class UserTestDataFactory : ITestDataFactory<User>
    {
        private User[] _users;
        private readonly DbContext _context;

        public UserTestDataFactory(DbContext context)
        {
            _context = context;
        }

        public User[] All()
        {
            return _users ?? (_users = Generate());
        }

        private static User[] Generate()
        {
            return new User[]
            {
                new User {Name = "Batman" },
                new User {Name = "Robin" },
                new User {Name = "The Joker" }
            };
        }
    }
}
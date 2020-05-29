using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BitcoGG_API.Models;

namespace BitcoGG_API.Services.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }
        //The user can't see what the password is'
        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }

        //The user can't see who the admin is
        public static User WithoutAdmin(this User user)
        {
            user.IsAdmin = 0;
            return user;
        }
    }
}

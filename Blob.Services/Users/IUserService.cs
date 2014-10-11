using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blob.Core;
using Blob.Core.Domain.Users;

namespace Blob.Services.Users
{
    public partial interface IUserService
    {
        IPagedList<User> GetAllUsers(string username = null, string fname = null, string lname = null, string Email = null, int? Active = null, int pageIndex = 0, int pageSize = 2147483647);

        void DeleteUser(User user);

        User GetUserById(int userId);

        IList<User> GetUserByIds(int[] userIds);

        User GetUserByUsername(string username);

        void InsertUser(User user);

        void UpdateUser(User user);
    }
}

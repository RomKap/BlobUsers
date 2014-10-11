using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blob.Core.Data;
using Blob.Core.Domain.Users;
using Blob.Core;

namespace Blob.Services.Users
{
    public partial class UserService : IUserService
    {
         #region Fields

         private readonly IRepository<User> _userRepository;

         #endregion

        #region Ctor

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion


        #region IUserService Members

        public IPagedList<User> GetAllUsers(string username = null, string fname = null, string lname = null, string Email = null, int? Active = null, int pageIndex = 0, int pageSize = 2147483647)
        {
            var query = _userRepository.Table;
            if (!String.IsNullOrWhiteSpace(username))
                query = query.Where(u => u.Username.Contains(username));

            if (!String.IsNullOrWhiteSpace(fname))
                query = query.Where(u => u.fname.Contains(fname));

            if (!String.IsNullOrWhiteSpace(lname))
                query = query.Where(u => u.lname.Contains(lname));

            if (Active != null)
            {
                bool active = true;
                bool.TryParse(Active.ToString(), out active);

                query = query.Where(u => u.Active == active);
            }

            query = query.OrderBy(u => u.fname).ThenBy(u => u.lname);

            var users = new PagedList<User>(query, pageIndex, pageSize);
            return users;
        }

        public void DeleteUser(User user)
        {
           if(user == null)
               throw new ArgumentNullException("user");
           
        }

        public User GetUserById(int userId)
        {
            if (userId == 0)
                throw new ArgumentNullException("user");

            return _userRepository.GetById(userId);
        }

        public IList<User> GetUserByIds(int[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
                return new List<User>();

            var query = from u in _userRepository.Table
                        where userIds.Contains(u.Id)
                        select u;

            var users = query.ToList();
            //sorted users
            var sortedUsers = new List<User>();
            foreach (int id in userIds)
            {
                var user = users.Find(x => x.Id == id);
                if (user != null)
                    sortedUsers.Add(user);
            }

            return sortedUsers;
        }

        public User GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var query = from u in _userRepository.Table
                        orderby u.Id
                        where u.Username == username
                        select u;

            var user = query.FirstOrDefault();
            return user;
        }

        public void InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            _userRepository.Update(user);

            //event notification
            //_eventPublisher.EntityUpdated(user); <-- implement later
        }

        #endregion
    }
}

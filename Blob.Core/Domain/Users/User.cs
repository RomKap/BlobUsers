using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blob.Core.Domain.Users
{
    public partial class User: BaseEntity
    {
        private ICollection<UserRoles> _userRoles;
        private ICollection<Address> _addresses;

        /// <summary>
        /// Ctor
        /// </summary>
        public User()
        {
        }
   
        public string Username { get; set; }
  
        public string fname { get; set; }
   
        public string lname { get; set; }
     
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<UserRoles> UserRoles
        {
            get { return _userRoles ?? (_userRoles = new List<UserRoles>()); }
            protected set { _userRoles = value; }
        }

        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }
        }
    }
}

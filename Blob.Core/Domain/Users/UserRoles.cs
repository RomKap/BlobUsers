using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blob.Core.Domain.Users
{
   public partial class UserRoles : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user role name
        /// </summary>
        public string Name { get; set; }

        public bool Active { get; set; }

    }
}

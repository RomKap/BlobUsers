using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blob.Web.Framework.Mvc;
using Blob.Web.Validators.Users;
using FluentValidation.Attributes;
using System.Web.Mvc;

namespace Blob.Web.Models.Users
{
    [Validator(typeof(UserValidator))]
    public partial class UserModel : BaseBlobEntityModel
    {
        public UserModel()
        {
        }

        [AllowHtml]
        public string Username { get; set; }

        [AllowHtml]
        public string fname { get; set; }

        [AllowHtml]
        public string lname { get; set; }

        [AllowHtml]
        public string Email { get; set; }

        [AllowHtml]
        public string Password { get; set; }

        public bool Active { get; set; }
    }
}

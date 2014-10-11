using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blob.Web.Framework.Mvc;
using System.Web.Mvc;

namespace Blob.Web.Models.Users
{
    public partial class UserListModel: BaseBlobModel
    {
        [AllowHtml]
        public string SearchUserName { get; set; }

        [AllowHtml]
        public string SearchFname { get; set; }

        [AllowHtml]
        public string SearchLname { get; set; }

        [AllowHtml]
        public string SearchEmail { get; set; }

    }
}
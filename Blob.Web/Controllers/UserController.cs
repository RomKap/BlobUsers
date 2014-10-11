using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blob.Services.Users;
using Blob.Web.Framework.Controllers;
using Blob.Web.Models.Users;

namespace Blob.Web.Controllers
{
    public partial class UserController : BaseController
    {

        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        #endregion

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var listModel = new UserListModel()
            {

            };

            return View(listModel);
        }

        //public ActionResult UserList(DataSourceRequest command, UserListModel model)
        //{
        //    var users = _userService.GetAllUsers();

        //    var gridModel = new DataSourceResult
        //    {
        //    };
        //}

    }
}

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
using Blob.Web.Framework.Kendoui;
using Blob.Core.Domain.Users;


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

        public ActionResult UserList(DataSourceRequest command, UserListModel model)
        {
            var users = _userService.GetAllUsers();         

            return View("List", users);
        }

        public ActionResult UserListAll(DataSourceRequest command, UserListModel model)
        {
            var users = _userService.GetAllUsers();

            return View("ListGrid", users);
        }

 
        public ActionResult UserListGrid(DataSourceRequest command, UserListModel model)
        {
            var users = _userService.GetAllUsers();

            var gridModel = new DataSourceResult
            {
                Data = users.Select(PrepareUserModelForList),
                Total = users.TotalCount
            };

            return Json(gridModel, JsonRequestBehavior.AllowGet);            
        }

        [NonAction]
        protected virtual UserModel PrepareUserModelForList(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                fname = user.fname,
                lname = user.lname,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Active = user.Active
            };
        }

    }
}

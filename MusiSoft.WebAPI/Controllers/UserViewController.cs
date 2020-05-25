using MusiSoft.Entities;
using MusiSoft.Helpers;
using MusiSoft.Services.Contract.Contract;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace MusiSoft.WebAPI.Controllers
{
    [Authorize]
    public class UserViewController : Controller
    {
        private IUserService userService;

        public UserViewController() : this(DependencyFactory.Resolve<IUserService>())
        {
        }

        public UserViewController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: UserView
        public ActionResult Index()
        {
            var users = userService.GetUsers();
            return View(users);
        }

        // GET: UserView/Details/5
        public ActionResult Details(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }

        // GET: UserView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserView/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(UserViewModel user)
        {
            try
            {
                var _company = ConfigurationSettings.AppSettings["company"];
                user.CompanyId = Int32.Parse(_company);
                userService.AddUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserView/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }

        // POST: UserView/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(int id, UserViewModel user)
        {
            try
            {
                var _company = ConfigurationSettings.AppSettings["company"];
                user.CompanyId = Int32.Parse(_company);
                userService.EditUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserView/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }

        // POST: UserView/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserViewModel user)
        {
            try
            {
                userService.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
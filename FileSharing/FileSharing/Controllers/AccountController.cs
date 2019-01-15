using FileSharing.Business.Interfaces;
using FileSharing.Entities.Core;
using FileSharing.Entities.Logging;
using FileSharing.Entities.Models;
using FileSharing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FileSharing.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBusinessLogic _bl;

        public AccountController(IBusinessLogic bl)
        {
            _bl = bl;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        #region Register
        // GET: Account/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                User oldUser = new User { Login = user.Login };
                if (_bl.Users.GetElement(oldUser) == null)
                {
                    if (user.Password == user.ConfirmPassword)
                    {
                        var userRole = _bl.UserRoles.GetElement(new UserRole { Name = "User" });

                        var newUser = new User()
                        {
                            Login = user.Login,
                            Email = user.Email,
                            Password = user.Password,
                            UserRoleId = userRole.Id
                        };

                        _bl.Users.Create(newUser);

                        var currentUser = _bl.Users.GetElement(newUser);

                        const int timeout = 72;

                        Response.Cookies["LoggedIn"].Value = "Accepted";
                        Response.Cookies["LoggedIn"].Expires = DateTime.Now.AddHours(timeout);

                        Response.Cookies["User"].Value = newUser.Login;
                        Response.Cookies["User"].Expires = DateTime.Now.AddHours(timeout);

                        Response.Cookies["Id"].Value = currentUser.Id.ToString();
                        Response.Cookies["Id"].Expires = DateTime.Now.AddHours(timeout);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пароли не совпадают");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такой логин уже существует");
                }
            }

            return View(user);
        }

        #endregion

        #region Авторизация

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserViewModel model)
        {
            ClearCookie();

            if (ModelState.IsValid)
            {

                var user = new User() { Login = model.Login };

                var currentUser = _bl.Users.GetElement(user);

                if (currentUser != null)
                {
                    if (model.Password == currentUser.Password)
                    {
                        const int timeout = 73;

                        Response.Cookies["Id"].Value = currentUser.Id.ToString();
                        Response.Cookies["Id"].Expires = DateTime.Now.AddHours(timeout);

                        Response.Cookies["LoggedIn"].Value = "Accepted";
                        Response.Cookies["LoggedIn"].Expires = DateTime.Now.AddHours(timeout);

                        var userRole = _bl.UserRoles.GetItemById(currentUser.UserRoleId);

                        if (userRole.Name == "User")
                        {
                            Response.Cookies["User"].Value = currentUser.Login;
                            Response.Cookies["User"].Expires = DateTime.Now.AddHours(timeout);
                        }
                        else if (userRole.Name == "Admin")
                        {
                            Response.Cookies["Admin"].Value = currentUser.Login;
                            Response.Cookies["Admin"].Expires = DateTime.Now.AddHours(timeout);
                        }
                        else if (userRole.Name == "Moder")
                        {
                            Response.Cookies["Moder"].Value = currentUser.Login;
                            Response.Cookies["Moder"].Expires = DateTime.Now.AddHours(timeout);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такого пользователя не существует");
                }
            }

            return View(model);
        }
        #endregion

        #region Метод удаления куков

        public void ClearCookie()
        {
            const int negativeTime = -73;

            if (Request.Cookies["Id"] != null)
            {
                Response.Cookies["Id"].Expires = DateTime.Now.AddHours(negativeTime);
                Response.Cookies["LoggedIn"].Expires = DateTime.Now.AddHours(negativeTime);
                Response.Cookies["User"].Expires = DateTime.Now.AddHours(negativeTime);
                Response.Cookies["Admin"].Expires = DateTime.Now.AddHours(negativeTime);
                Response.Cookies["Moder"].Expires = DateTime.Now.AddHours(negativeTime);
            }
        }

        #endregion

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            ClearCookie();

            return RedirectToAction("Index", "Home");
        }

        //GET, POST: Account/GetAdmin
        #region Получение прав администратора

        [Auth]
        public ActionResult GetAdmin()
        {
            int id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);

            var user = _bl.Users.GetItemById(id);

            var model = new GetRightsUserViewModel { Id = user.Id };

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAdmin(GetRightsUserViewModel model)
        {
            const int timeCookie = 72;
            const int negativeTime = -73;

            if (ModelState.IsValid)
            {
                var user = _bl.Users.GetItemById(model.Id);

                if (model.SecurityCode == "qm16po007fh")
                {
                    if (user.Password == model.Password)
                    {
                        var userRole = _bl.UserRoles.GetElement(new UserRole { Name = "Admin" });

                        user.UserRoleId = userRole.Id;

                        Response.Cookies["User"].Expires = DateTime.Now.AddHours(negativeTime);
                        Response.Cookies["Moder"].Expires = DateTime.Now.AddHours(negativeTime);

                        Response.Cookies["Admin"].Value = user.Email;
                        Response.Cookies["Admin"].Expires = DateTime.Now.AddHours(timeCookie);


                        _bl.Users.Update(user);

                        return RedirectToAction("AccountIndex", "Manage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверный пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный код");
                }
            }

            return View(model);
        }
        #endregion

        //GET, POST: Account/GetModer
        #region Получение прав модератора

        [Auth]
        public ActionResult GetModer()
        {
            int id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);

            var user = _bl.Users.GetItemById(id);

            var model = new GetRightsUserViewModel { Id = user.Id };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetModer(GetRightsUserViewModel model)
        {
            const int timeCookie = 72;
            const int negativeTime = -73;

            if (ModelState.IsValid)
            {
                var user = _bl.Users.GetItemById(model.Id);

                if (model.SecurityCode == "bmd78zl4r1")
                {
                    if (user.Password == model.Password)
                    {
                        var userRole = _bl.UserRoles.GetElement(new UserRole { Name = "Moder" });

                        user.UserRoleId = userRole.Id;

                        Response.Cookies["User"].Expires = DateTime.Now.AddHours(negativeTime);
                        Response.Cookies["Admin"].Expires = DateTime.Now.AddHours(negativeTime);

                        Response.Cookies["Moder"].Value = user.Email;
                        Response.Cookies["Moder"].Expires = DateTime.Now.AddMinutes(timeCookie);

                        _bl.Users.Update(user);

                        return RedirectToAction("AccountIndex", "Manage");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверный пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный код");
                }
            }

            return View(model);
        }
        #endregion
    }
}
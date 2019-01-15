using PagedList;
using PagedList.Mvc;
using FileSharing.Entities.Core;
using FileSharing.Entities.Models;
using FileSharing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileSharing.Business.Interfaces;
using FileSharing.Entities.Logging;

namespace FileSharing.Controllers
{
    public class ManageController : Controller
    {
        private readonly IBusinessLogic _bl;

        private const int PAGE_SIZE = 2;

        public ManageController(IBusinessLogic bl)
        {
            _bl = bl;
        }
        // GET: Manage
        [Auth]
        public ActionResult AccountIndex(int? id)
        {
            if(id == null)
            {
                id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);
            }
            

            var user = _bl.Users.GetItemById(id);
            var userRole = _bl.UserRoles.GetItemById(user.UserRoleId);

            var model = new AccountIndexViewModel()
            {
                Id = id.Value,
                Login = user.Login,
                Email = user.Email,
                UserRoleName = userRole.Name
            };

            return View(model);
        }

        [HttpGet]
        [Auth]
        [Admin]
        public ActionResult AddUser()
        {
            ViewBag.UserRoles = GetSelectListUserRoles();

            return View(new AddUserByAdminViewModel());
        }

        [HttpPost]
        [Auth]
        [Admin]
        public ActionResult AddUser(AddUserByAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                User oldUser = new User { Login = model.Login };
                if (_bl.Users.GetElement(oldUser) == null)
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        var userRole = _bl.UserRoles.GetElement(new UserRole { Name = model.UserRoleName });

                        var newUser = new User()
                        {
                            Login = model.Login,
                            Email = model.Email,
                            Password = model.Password,
                            UserRoleId = userRole.Id
                        };

                        _bl.Users.Create(newUser);

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

            return View(model);
        }

        private SelectList GetSelectListUserRoles()
        {
            var userRoles = _bl.UserRoles.GetAll();

            var list = new List<string>();

            foreach(var userRole in userRoles)
            {
                list.Add(userRole.Name);
            }

            return new SelectList(list);
        }

        [Auth]
        [Admin]
        public ActionResult ListOfUsers(int? page, string login)
        {
            int pageNumber = (page ?? 1);

            var users = _bl.Users.GetAll();

            if(login != null)
            {
                users = users.Where(m => m.Login.Contains(login));
            }

            var models = new List<IndexUserViewModel>();

            foreach(var user in users)
            {
                var userRole = _bl.UserRoles.GetItemById(user.UserRoleId);

                models.Add(new IndexUserViewModel()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Email = user.Email,
                    UserRoleName = userRole.Name
                });
            }

            return View(models.ToPagedList(pageNumber,PAGE_SIZE));
        }

        // GET: Manage/EditUserData
        [Auth]
        public ActionResult EditUserData(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);
            }

            User user = _bl.Users.GetItemById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            var model = new EditUserViewModel()
            {
                Id = id.Value,
                Login = user.Login,
                Email = user.Email 
            };

            return View(model);
        }

        // POST: Manage/EditUserData
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserData(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _bl.Users.GetItemById(model.Id);

                if (user == null)
                {
                    Logger.Log.Error("EditUserData - user not found");

                    return HttpNotFound();
                }

                user.Login = model.Login;
                user.Email = model.Email;

                _bl.Users.Update(user);

                return RedirectToAction("AccountIndex");
            }
            return View(model);
        }

        //GET: Manage/EditUserPassword
        [Auth]
        [HttpGet]
        public ActionResult EditUserPassword(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);
            }

            EditUserPasswordViewModel model = new EditUserPasswordViewModel()
            {
                Id = id.Value
            };

            return View(model);
        }

        //POST: Manage/EditUserPassword
        [Auth]
        [HttpPost]
        public ActionResult EditUserPassword(EditUserPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _bl.Users.GetItemById(model.Id);

                if (user == null)
                {
                    Logger.Log.Error("EditUserPassword - user not found");

                    return HttpNotFound();
                }

                if (user.Password == model.OldPassword)
                {
                    if (model.NewPassword == model.ConfirmPassword)
                    {
                        user.Password = model.NewPassword;

                        _bl.Users.Update(user);

                        return RedirectToAction("AccountIndex");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный пароль");
                }
            }

            return View(model);
        }

        // GET: Manage/Delete/5
        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);
            }

            var user = _bl.Users.GetItemById(id);

            if (user == null)
            {
                Logger.Log.Error("Delete - user not found");

                return HttpNotFound();
            }

            DeleteUserViewModel model = new DeleteUserViewModel()
            {
                Id = id.Value,
                Login = user.Login
            };

            return View(model);
        }

        // POST: Manage/Delete/5
        [Auth]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DeleteUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(Request.Cookies["Id"].Value != model.Id.ToString() && Request.Cookies["Admin"] != null)
                {                   
                    int id = Convert.ToInt32(Request.Cookies["Id"].Value);

                    var admin = _bl.Users.GetItemById(id);

                    if(admin.Password == model.Password)
                    {
                        var user = _bl.Users.GetItemById(model.Id);

                        _bl.Users.Delete(user);
                    }
                }
                else
                {
                    var user = _bl.Users.GetItemById(model.Id);

                    if (user.Password == model.Password)
                    {
                        _bl.Users.Delete(user);

                        ClearCookie();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

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
    }
}
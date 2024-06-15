using AdminDashboard.Controls;
using AdminDashboard.Models.Table;
using AdminDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewConfig.IsShowNavigationBar = false;

            return View();
        }

        public ActionResult Login(Users user)
        {
            var login = Sqlbulider.GetValue<Users>("email", user.email, "password", user.password, "usertype", "1");
            if (login.Count() > 0)
            {
                SessionControls<Users>.SetValue("LoginUser", login.FirstOrDefault());
                return RedirectToAction("Index", "Home");
                
            }

            else
            {
                TempData["IsLoginFail"] = true;
                return RedirectToAction(nameof(Index));
            }
        }


        public ActionResult Signout()
        {
            SessionControls<Users>.ClearValue("LoginUser");
            return RedirectToAction(nameof(Index));
        }
    }
}

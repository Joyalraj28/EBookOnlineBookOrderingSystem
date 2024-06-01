using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBookOnlineBookOrderingSystem.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            ViewConfig.IsShowNavigationBar = false;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Users user)
        {
            return RedirectToAction("Index","Home");
        }
    }
}
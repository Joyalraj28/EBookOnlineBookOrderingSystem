using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Services;
using Newtonsoft.Json;
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
           var data = TempData["IsLoginFail"];
            return View();
        }

        public ActionResult Login(Users user)
        {
            var login = Sqlbulider.GetValue<Users>("email", user.email, "password", user.password);
            if (login.Count() > 0)
            {
                List<Spr_GetAddCardInfoByUser> getAddCardInfo = Sqlbulider.Procedure<Spr_GetAddCardInfoByUser>(new
                {
                    @userid = login.FirstOrDefault().id
                }).ToList();

                if (getAddCardInfo.Count > 0)
                {
                    SessionControls<List<Spr_GetAddCardInfoByUser>>.SetValue("AddToCardInfo", getAddCardInfo);
                }


                SessionControls<bool>.SetValue("IsOrder", Sqlbulider.Count<MOrder>() > 0);

                SessionControls<Users>.SetValue("LoginUser", login.FirstOrDefault());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["IsLoginFail"] = true;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
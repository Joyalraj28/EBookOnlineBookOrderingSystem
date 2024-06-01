using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBookOnlineBookOrderingSystem.Models;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Services;

namespace EBookOnlineBookOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeModel { 
                Books = Sqlbulider.Get<Book>().ToList()
            });
        }
        public ActionResult ViewBook(string id)
        {
            var selectbook = Sqlbulider.GetValue<Book>("id", id).FirstOrDefault();
            return View(selectbook);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
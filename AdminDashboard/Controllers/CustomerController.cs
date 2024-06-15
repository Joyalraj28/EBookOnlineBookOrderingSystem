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
    public class CustomerController : Controller
    {
        public CustomerController()
        {
            ViewConfig.IsShowNavigationBar = true;
        }

        // GET: Customer
        public ActionResult Index()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View(Sqlbulider.GetValue<Users>("usertype","2"));
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ViewConfig.IsUserLogin)
                {
                    TempData["snackbar"] = "Login is Required";
                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (!ViewConfig.IsUserLogin)
                {
                    TempData["snackbar"] = "Login is Required";
                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ViewConfig.IsUserLogin)
                {
                    TempData["snackbar"] = "Login is Required";
                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

﻿using AdminDashboard.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // POST: Order/Create
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }



            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // POST: Order/Delete/5
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

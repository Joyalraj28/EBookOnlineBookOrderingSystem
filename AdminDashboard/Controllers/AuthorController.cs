using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminDashboard.Controls;
using AdminDashboard.Models.Table;
using AdminDashboard.Services;

namespace AdminDashboard.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View(Sqlbulider.Get<Author>());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            try
            {
                // TODO: Add insert logic here
                int id = Sqlbulider.Count<Author>() + 1;

                Sqlbulider.Add(new Author
                {
                    id = id,
                    name = collection["name"]
                });

                TempData["snackbar"] = "Successfully Insert Author details";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["snackbar"] = "Fail to Insert Author details";
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            var author = Sqlbulider.GetValue<Author>("id", id.ToString()).FirstOrDefault();
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                if (!ViewConfig.IsUserLogin)
                {
                    TempData["snackbar"] = "Login is Required";
                    return RedirectToAction("Index", "Login");
                }

                // TODO: Add update logic here
                Sqlbulider.Update(new Author
                {
                    id = id,
                    name = collection["name"]
                });

                TempData["snackbar"] = "Successfully Update Author details";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["snackbar"] = "Fail to Update Author details";
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Author/Delete/5
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

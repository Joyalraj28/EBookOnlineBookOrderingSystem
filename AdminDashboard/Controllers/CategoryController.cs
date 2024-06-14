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
    public class CategoryController : Controller
    {
        public CategoryController()
        {
            ViewConfig.IsShowNavigationBar = true;
        }

        // GET: Category
        public ActionResult Index()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View(Sqlbulider.Get<Category>());
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        // POST: Category/Create
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

                int id = Sqlbulider.Count<Category>() + 1;

                Sqlbulider.Add(new Category
                {
                    id = id,
                    name = collection["name"]
                });

                TempData["snackbar"] = "Successfully Insert Category details";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["snackbar"] = "Fail to Insert Category details";
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            var category = Sqlbulider.GetValue<Category>("id", id.ToString()).FirstOrDefault();
            return View(category);
        }

        // POST: Category/Edit/5
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



                Sqlbulider.Add(new Category
                {
                    id = id,
                    name = collection["name"]
                });
                TempData["snackbar"] = "Successfully Update Category details";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["snackbar"] = "Fail to update Category details";
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (!ViewConfig.IsUserLogin)
                {
                    TempData["snackbar"] = "Login is Required";
                    return RedirectToAction("Index", "Login");
                }


                Sqlbulider.Delete<Category>(id);
                TempData["snackbar"] = "Successfully delete Book details";
                return View();

            }
            catch (Exception)
            {
                TempData["snackbar"] = "Fail to delete Book details";
                return View();
            }
        }
    }
}

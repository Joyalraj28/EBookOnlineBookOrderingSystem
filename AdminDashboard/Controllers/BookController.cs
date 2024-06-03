using AdminDashboard.Models.Procedure;
using AdminDashboard.Models.Table;
using AdminDashboard.Models.ViewModel;
using AdminDashboard.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View(Sqlbulider.Procedure<Spr_GetBookInfo>());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            //Get book
            var book = Sqlbulider.GetValue<Book>("id", id.ToString());

            //Get all Autors
            var Autors = Sqlbulider.Get<Author>().ToList();

            //Get all Catergorys
            var Catergorys = Sqlbulider.Get<Category>().ToList();

            return View(new BookViewModel
            {
                Book = book.FirstOrDefault(),
                Authors = Autors,
                Catergories = Catergorys
            });
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(BookViewModel model)
        {
            if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
            {
                string fileName = Path.GetFileName(model.ImageFile.FileName);
                string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(path);

                // Optionally, save the file path to the database or perform other operations

                ViewBag.Message = "Image uploaded successfully.";
            }
            else
            {
                ViewBag.Message = "Please select an image file.";
            }

            return View(model);
        }
    }
}

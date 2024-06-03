using AdminDashboard.Models.Procedure;
using AdminDashboard.Models.Table;
using AdminDashboard.Models.ViewModel;
using AdminDashboard.Service;
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
            var book = Sqlbulider.GetValue<Book>("id", id.ToString()).FirstOrDefault();

            if(book.bookimg != null)
            {
                if(!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                }

                var img = CustomImageConverter.ByteArrayToImage(book.bookimg);

                var fileName = Path.GetFileName("img.png");
                var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                img.Save(path);

                ViewBag.ImagePath = "~/UploadedImages/" + fileName;


            }

            //Get all Autors
            var Autors = Sqlbulider.Get<Author>().ToList();

            //Get all Catergorys
            var Catergorys = Sqlbulider.Get<Category>().ToList();

            return View(new BookViewModel
            {
                Book = book,
                Authors = Autors,
                Catergories = Catergorys
            });
        }


        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                model.Book.bookimg = CustomImageConverter.ImageToByteArray(model.ImageFile);

                Sqlbulider.Update(model.Book,new { @Img = model.Book.bookimg });

                return RedirectToAction("Index");
            }
            catch(Exception ex)
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
    }
}

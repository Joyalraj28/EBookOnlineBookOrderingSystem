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

            var book = Sqlbulider.Procedure<Spr_GetBookInfo>(new { @bookid = id }).FirstOrDefault();
            if (book.bookimg != null)
            {
                if (!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                }

                var img = CustomImageConverter.ByteArrayToImage(book.bookimg);

                var fileName = Path.GetFileName("img" + book.id + ".png");
                var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                img.Save(path);

                ViewBag.ImagePath = "~/UploadedImages/" + fileName;


            }

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var Autors = new List<SelectListItem>();
            //Get all Autors
            Sqlbulider.Get<Author>().ToList().ForEach(a => 
            {
                Autors.Add(new SelectListItem { Value = a.id.ToString(), Text = a.name }) ;
            });

            Autors[0].Selected = true;

            //Get all Catergorys
            var Catergorys = new List<SelectListItem>();
            Sqlbulider.Get<Category>().ToList().ForEach(c =>
            {
                Catergorys.Add(new SelectListItem {Value =c.id.ToString(), Text = c.name });

            });

            Catergorys[0].Selected = true;


            return View(new BookViewModel { 
                Authors = Autors,
                Catergories = Catergorys,
            });
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookViewModel model,FormCollection form)
        {
            try
            {
                
                object parm = null;
                // TODO: Add insert logic here
                if (model.ImageFile != null)
                {
                    model.Book.bookimg = CustomImageConverter.ImageToByteArray(model.ImageFile);
                    parm = new { @Img = model.Book.bookimg };
                }

                int id = Sqlbulider.Count<Book>()+1;

                Sqlbulider.Add(new Book
                {
                    id = id,
                    name = form["Book.name"],
                    price = double.Parse(form["Book.price"]),
                    catergoryid = int.Parse(form["SelectCatergories"]),
                    authorid = int.Parse(form["SelectAuthors"]),
                    bookimg = model.Book.bookimg,
                    description = form["Book.description"],
                    quantity = int.Parse(form["Book.quantity"])
                }, parm);

                TempData["snackbar"] = "Successfully Insert Book details";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["snackbar"] = "Fail to Insert Book details";
                return RedirectToAction("Index");
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

                var fileName = Path.GetFileName("img"+book.id+".png");
                var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                img.Save(path);

                ViewBag.ImagePath = "~/UploadedImages/" + fileName;


            }

            var Autors = new List<SelectListItem>();
            //Get all Autors
            Sqlbulider.Get<Author>().ToList().ForEach(a => {
                Autors.Add(new SelectListItem { Value = a.id.ToString(), Text = a.name,Selected=book.authorid == a.id });
            });

            //Get all Catergorys
            var Catergorys = new List<SelectListItem>();
            Sqlbulider.Get<Category>().ToList().ForEach(c =>
            {
                Catergorys.Add(new SelectListItem {Value = c.id.ToString() ,Text = c.name, Selected = book.authorid == c.id });

            });


            return View(new BookViewModel
            {
                Book = book,
                Authors = Autors,
                Catergories = Catergorys,
               
            });
        }


        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookViewModel model,FormCollection form)
        {
            try
            {
                object parm = null;
                // TODO: Add update logic here
                if (model.ImageFile != null)
                {
                    model.Book.bookimg = CustomImageConverter.ImageToByteArray(model.ImageFile);
                    parm = new { @Img = model.Book.bookimg };
                }

      
                Sqlbulider.Update(new Book { 
                    id = int.Parse(form["Book.id"]),
                    name = form["Book.name"],
                    price = double.Parse(form["Book.price"]),
                    catergoryid = int.Parse(form["SelectCatergories"]),
                    authorid = int.Parse(form["SelectAuthors"]),
                    bookimg = model.Book.bookimg,
                    description = form["Book.description"],
                    quantity = int.Parse(form["Book.quantity"])
                }, parm);

                TempData["snackbar"] = "Successfully update Book details";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["snackbar"] = "Fail to Update Book details";
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Sqlbulider.Delete<Book>(id);
                TempData["snackbar"] = "Successfully delete Book details";
                return View();

            }
            catch (Exception)
            {
                TempData["snackbar"] = "Fail to delete Book details";
                return View();
            }
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

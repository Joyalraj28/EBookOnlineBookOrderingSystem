using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models;
using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Service;
using EBookOnlineBookOrderingSystem.Services;

namespace EBookOnlineBookOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewConfig.IsShowNavigationBar = true;
        }
        public ActionResult Index()
        {
           var Book = Sqlbulider.Get<Book>().ToList();

            List<CustomBookModel> customBookModels = new List<CustomBookModel>();
          
            foreach (var item in Book)
            {
                CustomBookModel customBookModel = new CustomBookModel();
                customBookModel.ImgPath = "~/Content/Image/NoImg.png";
                if (item.bookimg != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                    }

                    var img = CustomImageConverter.ByteArrayToImage(item.bookimg);

                    var fileName = Path.GetFileName("img" + item.id + ".png");
                    var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                    img.Save(path);

                    customBookModel.ImgPath = "~/UploadedImages/" + fileName;


                }
                

                customBookModel.Book = item;

                customBookModels.Add(customBookModel);
            }

            return View(new HomeModel { 
                Books = customBookModels
            });
        }
        public ActionResult ViewBook(string id)
        {
            var selectbook = Sqlbulider.Procedure<Spr_GetBookInfo>(new {
                @bookid = id
            }).FirstOrDefault();


         
            CustomBookModel customBookModel = new CustomBookModel();
            customBookModel.ImgPath = "~/Content/Image/NoImg.png";
            if (selectbook.bookimg != null)
            {
                if (!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                }

                var img = CustomImageConverter.ByteArrayToImage(selectbook.bookimg);

                var fileName = Path.GetFileName("img" + selectbook.id + ".png");
                var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                img.Save(path);

                customBookModel.ImgPath = "~/UploadedImages/" + fileName;


            }

            customBookModel.BookInfo = selectbook;

            return View(customBookModel);
        }

        public ActionResult BuyNow(Buybook buy)
        {
            return View();
        }

        public ActionResult Addtocard(string id)
        {
            var book = Sqlbulider.GetValue<Book>("id", id).FirstOrDefault();

            if(book != null)
            {
                var aid = Sqlbulider.Count<AddToCard>() + 1;

                Sqlbulider.Add<AddToCard>(new AddToCard
                {
                    id = aid,
                    bookid = book.id,
                    price = book.price,
                    quantity = 1,
                    userid = 1,

                });
            }

            return RedirectToAction(nameof(Index));
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

        public ActionResult Signout()
        {
            SessionControls<Users>.ClearValue("LoginUser");
            SessionControls<Spr_GetAddCardInfoByUser>.ClearValue("AddToCardInfo");
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Search(FormCollection form)
        {

 
            var Book = Sqlbulider.Get<Book>().Where(c => c.name.IndexOf(form["Serach"], StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            List<CustomBookModel> customBookModels = new List<CustomBookModel>();

            foreach (var item in Book)
            {
                CustomBookModel customBookModel = new CustomBookModel();
                customBookModel.ImgPath = "~/Content/Image/NoImg.png";
                if (item.bookimg != null)
                {
                    if (!Directory.Exists(Server.MapPath("~/UploadedImages/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/UploadedImages/"));
                    }

                    var img = CustomImageConverter.ByteArrayToImage(item.bookimg);

                    var fileName = Path.GetFileName("img" + item.id + ".png");
                    var path = Path.Combine(Server.MapPath("~/UploadedImages/"), fileName);
                    img.Save(path);

                    customBookModel.ImgPath = "~/UploadedImages/" + fileName;


                }


                customBookModel.Book = item;

                customBookModels.Add(customBookModel);
            }

            return View("Index",new HomeModel
            {
                Books = customBookModels
            });

        }

    }
}
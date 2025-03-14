﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models;
using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Models.ViewModel;
using EBookOnlineBookOrderingSystem.Service;
using EBookOnlineBookOrderingSystem.Services;
using Newtonsoft.Json;

namespace EBookOnlineBookOrderingSystem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewConfig.IsShowNavigationBar = true;
        }
        public ActionResult Index(int PageNumber = 1)
        {
           var Book = Sqlbulider.Get<Book>().ToList();

            List<CustomBookModel> customBookModels = new List<CustomBookModel>();
          
            foreach (var item in Book)
            {
                //Load Image
                CustomBookModel customBookModel = new CustomBookModel();
                customBookModel.ImgPath = "~/Content/Image/NoImg.png";
                if (item.bookimg != null)
                {
                    //If not exist create directory
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

            PaginationViewModel<CustomBookModel> bookpaginationViewModel = new PaginationViewModel<CustomBookModel>(customBookModels,6);
            var pagevieemodel = bookpaginationViewModel.GetPageItem(PageNumber);


            return View(new HomeModel { 
                Books = pagevieemodel
            });
        }
        public ActionResult PageMove(string PageNumber)
        {
            return RedirectToAction("Index", new
            {
                PageNumber = int.Parse(PageNumber)
            });
        }

        public void ReLoadAddtoCard()
        {
            var login = SessionControls<Users>.GetValue("LoginUser");
            List<Spr_GetAddCardInfoByUser> getAddCardInfo = Sqlbulider.Procedure<Spr_GetAddCardInfoByUser>(new
            {
                @userid = login.id
            }).ToList();



            SessionControls<List<Spr_GetAddCardInfoByUser>>.SetValue("AddToCardInfo", getAddCardInfo);

        }

        public ActionResult DeleteAddCartBook(string id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            //Delete item
            Sqlbulider.Delete<AddToCard>(int.Parse(id));
        
            //Reload
            ReLoadAddtoCard();

           return RedirectToAction(nameof(Index));
        }

        public ActionResult ViewBook(string id)
        {

            var selectbook = Sqlbulider.Procedure<Spr_GetBookInfo>(new {
                @bookid = id
            }).FirstOrDefault();

            CustomBookModel customBookModel = new CustomBookModel();
            //Load Image
            customBookModel.ImgPath = "~/Content/Image/NoImg.png";
            if (selectbook.bookimg != null)
            {
                //If not exist create directory
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

        
        public ActionResult BuyNow(string id)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            var book = Sqlbulider.Procedure<Spr_GetBookInfo>(new { @bookid = id }).FirstOrDefault();
           
            return View(new Buybook { SelectBook = book });
        }

        public ActionResult Addtocard(string id)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            var book = Sqlbulider.GetValue<Book>("id", id).FirstOrDefault();

           var isanlreadyexits = Sqlbulider.GetValue<AddToCard>("bookid", id);

            var loginuser = SessionControls<Users>.GetValue("LoginUser");

            if (book != null)
            {
                if (isanlreadyexits.Count() <= 0)
                {
                    var aid = Sqlbulider.Count<AddToCard>() + 1;

                    //Insert Add to card info in Database
                    Sqlbulider.Add(new AddToCard
                    {
                        id = aid,
                        bookid = book.id,
                        price = book.price,
                        quantity = 1,
                        userid = loginuser.id,

                    });
                }

                else
                {

                    var addtocartinfo = Sqlbulider.GetValue<AddToCard>("bookid",id).FirstOrDefault();

                    Sqlbulider.Update<AddToCard>(new AddToCard
                    {
                        id = addtocartinfo.id,
                        bookid = book.id,
                        price = book.price,
                        quantity = (addtocartinfo.quantity+=1),
                        userid = loginuser.id,

                    });

                }

            }
            ReLoadAddtoCard();
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

            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

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

            PaginationViewModel<CustomBookModel> bookpaginationViewModel = new PaginationViewModel<CustomBookModel>(customBookModels,6);
            var pagevieemodel = bookpaginationViewModel.GetPageItem();

            return View("Index",new HomeModel
            {
                Books = pagevieemodel
            });

        }

        public ActionResult AddItem(string bid,string BuyQuantity)
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
        
       
        public ActionResult OrderList()
        {
            if(!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            var loginuser = SessionControls<Users>.GetValue("LoginUser");
            return View(Sqlbulider.GetValue<MOrder>("userid", loginuser.id.ToString()));
        }

        public ActionResult ViewOrder(string id)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            return View(Sqlbulider.GetValue<TOrder>("morderid",id));
        }

        public ActionResult PlaceOrder(FormCollection formCollection,PaymentModel payment)
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            var book = Sqlbulider.GetValue<Book>("id", formCollection["bid"]).FirstOrDefault();

            var Morderid = Sqlbulider.Count<MOrder>() + 1;
            var TorderId = Sqlbulider.Count<TOrder>() + 1;

            return RedirectToAction("Index", "Payment", new
            {
                payment = JsonConvert.SerializeObject(new PaymentModel
                {
                    Amount = book.price * int.Parse(formCollection["BuyQuantity"]),
                    mOrder = new MOrder { id = Morderid, paymenttype = "Card",paymentdate=DateTime.Now,Status=2 },
                    Users = SessionControls<Users>.GetValue("LoginUser"),
                    tOrder = new List<TOrder> {
                    new TOrder(){
                    id = TorderId,
                    bookid = book.id,
                    morderid = Morderid,
                    price = book.price * int.Parse(formCollection["BuyQuantity"]),
                    quantity = int.Parse(formCollection["BuyQuantity"])
                    }
                    }
                })
            });
        }

        public ActionResult ViewMoreAllAddtoCart()
        {

            if (!ViewConfig.IsUserLogin)
            {
                TempData["DangerAlert"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }

            var user = SessionControls<Users>.GetValue("LoginUser");

            PlaceAddToCardItems placeAddToCardItems = new PlaceAddToCardItems();
            placeAddToCardItems.AddToCardItems = new List<PlaceAddToCardItem>();
            int id = 1;
              Sqlbulider.Procedure<Spr_GetAddCardInfoByUser>(new { @userid = user.id }).ToList().ForEach(data =>
              {
                  placeAddToCardItems.AddToCardItems.Add(new PlaceAddToCardItem { AddToCard = data , CheckID = id});
                  id += 1;
              });


            return View(placeAddToCardItems);
        }

        [HttpPost]
        public ActionResult PlaceOrderAddToCart(FormCollection formCollection)
        {

          
            var Morderid = Sqlbulider.Count<MOrder>() + 1;
            var TorderId = Sqlbulider.Count<TOrder>() + 1;

            double amount = 0;

            int count = int.Parse(formCollection["AddToCardCount"]);
            List<TOrder> torderlist = new List<TOrder>();
            if(count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    if(formCollection.AllKeys.Contains("["+i+ "]isActive"))
                    {

                        var book = Sqlbulider.GetValue<Book>("id", formCollection["["+i+"]bid"]).FirstOrDefault();

                       var torder = new TOrder
                        {
                            id = TorderId,
                            bookid = book.id,
                            morderid = Morderid,
                            price = book.price * int.Parse(formCollection["[" + i + "]addcartQTY"]),
                            quantity = int.Parse(formCollection["["+i+"]addcartQTY"])
                        };


                        torderlist.Add(torder);
                        amount += torder.price;
                        TorderId++;
                    }
                }
            }


            return RedirectToAction("Index", "Payment", new
            {
                payment = JsonConvert.SerializeObject(new PaymentModel
                {
                    Amount = amount,
                    mOrder = new MOrder { id = Morderid, paymenttype = "Card", paymentdate = DateTime.Now, Status = 2 },
                    Users = SessionControls<Users>.GetValue("LoginUser"),
                    tOrder = torderlist,
                    IsAdToCard = true
                })
            });

        }
    }
}
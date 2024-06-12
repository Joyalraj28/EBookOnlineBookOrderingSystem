using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBookOnlineBookOrderingSystem.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(string payment=null)
        {
            //payment.Users = SessionControls<Users>.GetValue("LoginUser");

            return View(payment);
        }

        public ActionResult PlaceOrder(FormCollection form)
        {

            int orderid = Sqlbulider.Count<MOrder>() + 1;

            var Users = SessionControls<Users>.GetValue("LoginUser");

            Sqlbulider.Add(new MOrder 
            {
                id = orderid,
                price = double.Parse(form["Amount"]),
                userid = Users.id,
                paymenttype = "Cart"
            });



            return View();
        }





        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payment/Create
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

        // GET: Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Payment/Edit/5
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

        // GET: Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Payment/Delete/5
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

using EBookOnlineBookOrderingSystem.Controls;
using EBookOnlineBookOrderingSystem.Models;
using EBookOnlineBookOrderingSystem.Models.Table;
using EBookOnlineBookOrderingSystem.Services;
using Newtonsoft.Json;
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
            var pay = JsonConvert.DeserializeObject<PaymentModel>(payment);
            pay.json = payment;
            return View(pay);
        }

        public ActionResult PlaceOrder(FormCollection form)
        {
            
            PaymentModel payment = JsonConvert.DeserializeObject<PaymentModel>((form["json"]));

            if (payment.mOrder != null && payment.tOrder != null && payment.tOrder.Count > 0)
            {

                payment.mOrder.price = payment.Amount;
                payment.mOrder.userid = payment.Users.id;
                Sqlbulider.Add(payment.mOrder);

                payment.tOrder.ForEach(torder =>
                {
                    if (torder != null)
                    {
                        Sqlbulider.Add(torder);
                    }
                });

                TempData["SuccessAlert"] = "The order will be successfully placed";
               
            }

            else
            {
               
                TempData["DangerAlert"] = "Fail to place an order. Please try again";
             

            }

            return RedirectToAction("Index", "Home");
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

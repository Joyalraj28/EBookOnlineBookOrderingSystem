using AdminDashboard.Controls;
using AdminDashboard.Models;
using AdminDashboard.Models.Table;
using AdminDashboard.Models.ViewModel;
using AdminDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!ViewConfig.IsUserLogin)
            {
                TempData["snackbar"] = "Login is Required";
                return RedirectToAction("Index", "Login");
            }


            List<OverviewCountBoxmodel> _overviewCountBox = new List<OverviewCountBoxmodel>();

            Random rnd = new Random();


            var lstModel = new List<ReportViewModel>();

            Sqlbulider.Get<Book>().ToList().ForEach(val => {

                lstModel.Add(new ReportViewModel
                {
                    DimensionOne = val.name,
                    Quantity = new Random().Next(val.quantity)

                });


            });



            return View(new HomeModel
            {
                TotalBook = Sqlbulider.Count<Book>(),
                TotalCustomer = Sqlbulider.Count<Users>(),
                TotalSales = 10,
                OverviewCountBoxRow = new List<OverviewCountBoxmodelRow>
                {
                    new OverviewCountBoxmodelRow
                    {
                        OverviewCountBox = _overviewCountBox
                    },

                },
                stackedViewModel = new StackedViewModel
                {

                    LstData = lstModel

                }

            });
        }

        
    }
}
using AdminDashboard.Models;
using AdminDashboard.Models.ViewModel;
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
            List<OverviewCountBoxmodel> _overviewCountBox = new List<OverviewCountBoxmodel>
            {
                new OverviewCountBoxmodel{
                    Title = "Count of User",
                    Count = "22"
                },
                 new OverviewCountBoxmodel{
                    Title = "Count of Profile",
                    Count = "25"
                },
                  new OverviewCountBoxmodel{
                    Title = "Count of Logs",
                    Count = "30"
                },
            };


            Random rnd = new Random();


            var lstModel = new List<ReportViewModel>()
            {
                 new ReportViewModel
                {
                    DimensionOne = "Joyalraj",
                    Quantity = rnd.Next( 10 )
                },

                new ReportViewModel
                {
                 DimensionOne = "Halith",
                Quantity = rnd.Next( 10 )
                },

                 new ReportViewModel
                {
                     DimensionOne = "Thushyanthan",
                     Quantity = rnd.Next( 10 )
                },

                new ReportViewModel
                {
                 DimensionOne = "Philp",
                 Quantity = rnd.Next( 10 )
                },
                  new ReportViewModel
                {
                 DimensionOne = "Sutha",
                 Quantity = rnd.Next( 10 )
                },
                   new ReportViewModel
                {
                 DimensionOne = "Bala",
                 Quantity = rnd.Next( 10 )
                },
                     new ReportViewModel
                {
                 DimensionOne = "SivaPriya",
                 Quantity = rnd.Next( 10 )
                },

                        new ReportViewModel
                {
                 DimensionOne = "Shithuja",
                 Quantity = rnd.Next( 10 )
                },


 };



            return View(new HomeModel
            {
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
    }
}
using AdminDashboard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models
{
    public class HomeModel
    {
        public int TotalBook { get; set; }
        public int TotalCustomer { get; set; }
        public int TotalSales { get; set; }

        public List<OverviewCountBoxmodelRow> OverviewCountBoxRow { get; set; }
        public StackedViewModel stackedViewModel { get; set; }
    }
}
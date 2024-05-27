using AdminDashboard.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models
{
    public class HomeModel
    {
        public List<OverviewCountBoxmodelRow> OverviewCountBoxRow { get; set; }
        public StackedViewModel stackedViewModel { get; set; }
    }
}
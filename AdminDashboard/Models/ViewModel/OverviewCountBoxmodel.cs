using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.ViewModel
{
    public class OverviewCountBoxmodel
    {
        public string Title { get; set; }
        public string Count { get; set; }
    }

    public class OverviewCountBoxmodelRow
    {
        public List<OverviewCountBoxmodel> OverviewCountBox { get; set; }
    }
}
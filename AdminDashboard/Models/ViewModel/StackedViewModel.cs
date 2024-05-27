using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.ViewModel
{
    public class StackedViewModel
    {
        public string StackedDimensionOne { get; set; }
        public List<ReportViewModel> LstData { get; set; }
    }
}
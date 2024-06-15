using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.Procedure
{
    public class Spr_GetOrderInfo
    {
        public int id { get; set; }
        public double price { get; set; }
        public string paymenttype { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime paymentdate { get; set; }
        public string Status { get; set; }
        //public string Feedback { get; set; }
    }
}
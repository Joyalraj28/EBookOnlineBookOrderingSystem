using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.Procedure
{
    public class Spr_GetTOrderInfo
    {
        public int id { get; set; }
        public double price { get; set; }
        public int morderid { get; set; }
        public int quantity { get; set; }
        public byte[] bookimg { get; set; }
        public string BookName { get; set; }
    }
}
using AdminDashboard.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.Table
{
    public class TOrder
    {
        [PrimaryKey]
        public int id { get; set; }
        public double price { get; set; }
        public int bookid { get; set; }
        public int morderid { get; set; }
        public int quantity { get; set; }
    }
}
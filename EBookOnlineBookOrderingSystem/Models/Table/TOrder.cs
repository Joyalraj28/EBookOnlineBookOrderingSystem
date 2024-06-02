using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class TOrder
    {
        public int id { get; set; }
        public double price { get; set; }
        public int bookid { get; set; }
        public int morderid { get; set; }
        public int quantity { get; set; }
    }
}
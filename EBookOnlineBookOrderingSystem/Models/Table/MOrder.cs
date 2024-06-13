using EBookOnlineBookOrderingSystem.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class MOrder
    {
        [PrimaryKey]
        public int id { get; set; }
        public double price { get; set; }
        public string paymenttype { get; set; }
        public int userid { get; set; }
        public DateTime paymentdate { get; set; }
        public int Status { get; set; }
        public string Feedback { get; set; }

    }
}
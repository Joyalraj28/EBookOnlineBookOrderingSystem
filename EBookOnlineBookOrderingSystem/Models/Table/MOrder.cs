﻿using EBookOnlineBookOrderingSystem.SqlAttribute;
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
        public int bookid { get; set; }
        public int morderid { get; set; }

    }
}
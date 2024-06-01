using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Procedure
{
    public class Spr_GetBookInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int catergoryid { get; set; }
        public int authorid { get; set; }
        public byte[] bookimg { get; set; }
        public string description { get; set; }
        public string authorname { get; set; }
        public string catergoryname { get; set; }

    }
}
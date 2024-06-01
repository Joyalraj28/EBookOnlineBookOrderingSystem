using EBookOnlineBookOrderingSystem.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class Book
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int catergoryid { get; set; }
        public int authorid { get; set; }
        public byte[] bookimg { get; set; }
        public string description { get; set; }
    }
}
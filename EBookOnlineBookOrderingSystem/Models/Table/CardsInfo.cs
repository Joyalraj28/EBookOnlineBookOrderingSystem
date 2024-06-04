using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class CardsInfo
    {
        public int CardNo { get; set; }
        public string Name { get; set; }
        public string CardType { get; set; }
        public double Amount { get; set; }
    }
}
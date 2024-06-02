using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models
{
    public class Buybook
    {
        public Spr_GetBookInfo SelectBook { get; set; }
        public int BuyQuantity { get; set; }

    }
}
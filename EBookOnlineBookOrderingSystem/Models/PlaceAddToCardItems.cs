using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models
{
    public class PlaceAddToCardItems
    {
      public bool IsActiveAll { get; set; }
      public List<PlaceAddToCardItem> AddToCardItems { get; set; }
    }

    public class PlaceAddToCardItem
    {
        public bool IsActive { get; set; }
        public Spr_GetAddCardInfoByUser AddToCard { get; set; }
    }



}
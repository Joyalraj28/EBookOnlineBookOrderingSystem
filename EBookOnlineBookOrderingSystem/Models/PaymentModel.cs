using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models
{
    public class PaymentModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Card Number Required")]
        public int CardNo { get; set; }
        public string AccountName { get; set; }
        public Users Users { get; set; }
        public CardsInfo cardsinfo { get; set; }
        public MOrder mOrder { get; set; }
        public List<TOrder> tOrder { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Amount Required")]
        public double Amount { get; set; }
        public string json { get; set; }
    }
}
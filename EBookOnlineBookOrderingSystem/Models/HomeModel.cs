using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models
{
    public class HomeModel
    {
        public string Serach { get; set; }
        public List<CustomBookModel> Books { get; set; }
    }
}
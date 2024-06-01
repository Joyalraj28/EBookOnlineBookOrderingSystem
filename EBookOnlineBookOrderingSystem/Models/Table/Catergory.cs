using EBookOnlineBookOrderingSystem.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class Catergory
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
    }
}
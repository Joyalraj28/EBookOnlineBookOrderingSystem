using EBookOnlineBookOrderingSystem.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models.Table
{
    public class Users
    {
        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int phoneNo { get; set; }
        public string email { get; set; }
        public string usertype { get; set; }
    }
}
using AdminDashboard.SqlAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.Table
{
    public class Author
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
    }
}
using AdminDashboard.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminDashboard.Models.ViewModel
{
    public class BookViewModel
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public Book Book { get; set; }

        public List<SelectListItem> Authors {get;set;}
        public SelectListItem SelectAuthors {get;set;}
        public List<SelectListItem> Catergories { get; set; }
        public SelectListItem SelectCatergories { get; set; }
    }
}
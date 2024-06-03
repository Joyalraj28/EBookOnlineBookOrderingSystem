using AdminDashboard.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDashboard.Models.ViewModel
{
    public class BookViewModel
    {
        public HttpPostedFileBase ImageFile { get; set; }
        public Book Book { get; set; }
        public Author SelectAuthors {get;set;}
        public List<Author> Authors {get;set;}
        public Category SelectCatergories { get; set; }
        public List<Category> Catergories { get; set; }
    }
}
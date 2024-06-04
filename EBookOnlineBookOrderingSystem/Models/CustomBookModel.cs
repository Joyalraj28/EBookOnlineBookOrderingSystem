using EBookOnlineBookOrderingSystem.Models.Procedure;
using EBookOnlineBookOrderingSystem.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookOnlineBookOrderingSystem.Models
{
    public class CustomBookModel
    {
        public Book Book { get; set; }
        public string ImgPath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public Spr_GetBookInfo BookInfo { get; set; }

    }
}
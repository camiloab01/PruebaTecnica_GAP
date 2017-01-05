using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatos_Client.Models
{
    public class ArticleStoreViewModel
    {
        public ArticleModel Article { get; set; }
        
        public IEnumerable<SelectListItem> Stores { get; set; } 
    }
}
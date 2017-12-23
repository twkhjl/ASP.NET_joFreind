using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestEF_new.Controllers
{
    public class PageController : Controller
    {
      
        public ActionResult Index()
        {
            return Redirect("front/index.html");
        }
      
    }
}

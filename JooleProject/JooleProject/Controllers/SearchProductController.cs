using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleProject.Controllers
{
    public class SearchProductController : Controller
    {
        // GET: SearchProduct
        public ActionResult SearchResult(string subCategory)
        {
            return View();
        }
    }
}
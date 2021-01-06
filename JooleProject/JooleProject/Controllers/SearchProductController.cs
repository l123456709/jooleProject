using JooleDAL;
using JooleService;
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
        public ActionResult SearchResult(string subCategory = "Sofas")
        {
            Service service = new Service();
            Dictionary<string, List<string>> typeFilters = service.GetAllTypeFilterBySubCategory(subCategory);
            Dictionary<string, List<decimal?>> techSpecFilter = service.GetAllTechSpecFilterBySubCategory(subCategory);
            string categoryName = service.GetCategoryBySubCategory(subCategory);
            List<Product> listOfProducts = service.GetProductsBySubCategory(subCategory);
            ViewBag.typeFilters = typeFilters;
            ViewBag.techSpecFilter = techSpecFilter;
            ViewBag.categoryName = categoryName;
            ViewBag.subCategory = subCategory;
            ViewBag.products = listOfProducts;
            return View();
        }
    }
}
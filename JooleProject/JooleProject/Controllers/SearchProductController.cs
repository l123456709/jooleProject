using JooleDAL;
using JooleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleProject.Models;


namespace JooleProject.Controllers
{
    public class SearchProductController : Controller
    {



        public ActionResult SearchResult(string subCategory = "Fans")
        {
            Service service = new Service();
            List<Category> categories = service.GetAllCategory();
            // identify which page now we are in
            Session["page"] = "Search";

            Dictionary<string, List<string>> typeFilters = service.GetAllTypeFilterBySubCategory(subCategory);
            Dictionary<string, List<decimal?>> techSpecFilter = service.GetAllTechSpecFilterBySubCategory(subCategory);
            string categoryName = service.GetCategoryBySubCategory(subCategory);
            List<Product> listOfProducts = service.GetProductsBySubCategory(subCategory);

            ViewBag.typeFilters = typeFilters;
            ViewBag.techSpecFilter = techSpecFilter;
            ViewBag.categoryName = categoryName;
            ViewBag.subCategory = subCategory;
            ViewBag.products = listOfProducts;
            return View(categories);
        }

        public ActionResult Summmary(int productId)
        {
            Service service = new Service();
            List<Category> categories = service.GetAllCategory();
            // identify which page now we are in
            Session["page"] = "Search";

            Dictionary<string, Dictionary<string, string>> productDetails = service.GetDetailsByProductId(productId);

            ViewBag.productDetails = productDetails;
            return View(categories);
        }

        [HttpPost]
        public ActionResult Compare(List<int> productsId)
        {
            Service service = new Service();
            List<Category> categories = service.GetAllCategory();
            // identify which page now we are in
            Session["page"] = "Search";

            return View(categories);
        }

        [HttpPost]
        public ActionResult Filter(List<int> fltVal, string subCategory)
        {
            Service service = new Service();
            ViewBag.products = service.GetProductsByTechSpecFilter(fltVal, subCategory);

            return PartialView();
        }
    }
}
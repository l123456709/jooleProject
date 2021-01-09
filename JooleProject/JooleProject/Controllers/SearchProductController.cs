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

        public ActionResult Test()
        {
            return View();
        }
        // GET: SearchProduct

        public ActionResult SearchResult(string subCategory = "Fans")
        {
            JooleDatabaseEntities entities = new JooleDatabaseEntities();
            CascadingModel model = new CascadingModel();
            foreach (var category in entities.Categories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Category_Name, Value = category.Category_ID.ToString() });
            }

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
            return View(model);
        }

        public ActionResult Summmary(int productId)
        {
            JooleDatabaseEntities entities = new JooleDatabaseEntities();
            CascadingModel model = new CascadingModel();
            foreach (var category in entities.Categories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Category_Name, Value = category.Category_ID.ToString() });
            }

            Service service = new Service();
            Dictionary<string, Dictionary<string, string>> productDetails = service.GetDetailsByProductId(productId);

            ViewBag.productDetails = productDetails;
            return View(model);
        }

        [HttpPost]
        public ActionResult Compare(List<int> productsId)
        {   
            Service service = new Service();
            ViewBag.productDetails = new List<Dictionary<string, Dictionary<string, string>>>();

            foreach (var item in productsId)
            {
                Dictionary<string, Dictionary<string, string>> productDetails = service.GetDetailsByProductId(item);
                ViewBag.productDetails.Add(productDetails);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Filter(List<int> fltVal, string subCategory)
        {
            Service service = new Service();
            ViewBag.products = service.GetProductsByTechSpecFilter(fltVal, subCategory);

            return PartialView();
        }

        public ActionResult _Search()
        {
            JooleDAL.JooleDatabaseEntities entities = new JooleDAL.JooleDatabaseEntities();
            CascadingModel model = new CascadingModel();
            foreach (var category in entities.Categories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Category_Name, Value = category.Category_ID.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult _Search(int? Category_ID, int? SubCategory_ID)
        {
            JooleDAL.JooleDatabaseEntities entities = new JooleDAL.JooleDatabaseEntities();
            CascadingModel model = new CascadingModel();
            foreach (var category in entities.Categories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Category_Name, Value = category.Category_ID.ToString() });
            }

            if (Category_ID.HasValue)
            {
                var subcategories = (from sub in entities.SubCategories
                                     where sub.Category_ID == Category_ID.Value
                                     select sub).ToList();
                foreach (var subcategory in subcategories)
                {
                    model.SubCategories.Add(new SelectListItem { Text = subcategory.SubCategory_Name, Value = subcategory.SubCategory_ID.ToString() });
                }

                /*if (stateId.HasValue)
                {
                    var cities = (from city in entities.Cities
                                  where city.StateId == stateId.Value
                                  select city).ToList();
                    foreach (var city in cities)
                    {
                        model.Cities.Add(new SelectListItem { Text = city.CityName, Value = city.CityId.ToString() });
                    }
                }*/
            }

            return View("SearchResult", model);
        }

    }
}
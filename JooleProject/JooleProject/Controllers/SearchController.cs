using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using JooleProject.ViewModels;
using JooleProject.Models;

namespace JooleProject.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // pass category data to SearchPage view
        public ActionResult SearchPageInitial()
        {
            JooleDAL.JooleDatabaseEntities db = new JooleDAL.JooleDatabaseEntities();
            
            var obj = db.Categories;
            var categoryname = (from s in db.Categories
                                select s.Category_Name);
            Session["categoryname"] = categoryname;
            
            return View("SearchPage");
        }
        /*
        public ActionResult Search()
        {
            return View();
        }*/
        
        public ActionResult Search()
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
        public ActionResult Search(int? categoryId, int? subcategoryId)
        {
            JooleDAL.JooleDatabaseEntities entities = new JooleDAL.JooleDatabaseEntities();
            CascadingModel model = new CascadingModel();
            foreach (var category in entities.Categories)
            {
                model.Categories.Add(new SelectListItem { Text = category.Category_Name, Value = category.Category_ID.ToString() });
            }

            if (categoryId.HasValue)
            {
                var subcategories = (from sub in entities.SubCategories
                              where sub.Category_ID == categoryId.Value
                              select sub).ToList();
                foreach (var subcategory in subcategories)
                {
                    model.SubCategories.Add(new SelectListItem { Text = subcategory.SubCategory_Name, Value = subcategory.SubCategory_ID.ToString() });
                }

                ViewBag.t = model;

                return View("View");

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

            return View(model);
        }
    }
}
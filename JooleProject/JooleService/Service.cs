using JooleDAL;
using JooleRepository;
using JooleService.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleService
{
    public class Service
    {   
        public static readonly JooleDatabaseEntities context = new JooleDatabaseEntities();
        UnitOfWork uow = new UnitOfWork(context);
        public Service()
        {

        }

        public Dictionary<string, List<string>> GetAllTypeFilterBySubCategory(string subCategory)
        {
            Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
            var subCategories = uow.SubCategory.GetAll();
            int subCategoryId = 0;
            var typeFilters = uow.TypeFilter.GetAll();

            foreach (var item in subCategories)
            {
                if (item.SubCategory_Name == subCategory)
                {
                    subCategoryId = item.SubCategory_ID;
                }
            }

            foreach (var item in typeFilters)
            {
                if (item.SubCategory_ID == subCategoryId)
                {
                    List<string> tmp = item.Type_Options.Split(';').ToList();
                    res.Add(item.Type_Name, tmp);
                }
            }

            return res;
        }

        public Dictionary<string, List<decimal?>> GetAllTechSpecFilterBySubCategory(string subCategory)
        {
            Dictionary<string, List<decimal?>> res = new Dictionary<string, List<decimal?>>();
            var subCategories = uow.SubCategory.GetAll();
            int subCategoryId = 0;
            var techSpecFilter = uow.TechSpecFilter.GetAll();

            foreach (var item in subCategories)
            {
                if (item.SubCategory_Name == subCategory)
                {
                    subCategoryId = item.SubCategory_ID;
                }
            }

            foreach (var item in techSpecFilter)
            {
                if (item.SubCategory_ID == subCategoryId)
                {
                    List<decimal?> tmp = new List<decimal?>();
                    tmp.Add(item.Min_Value);
                    tmp.Add(item.Max_Value);
                    string propertyName = uow.Property.GetByID(item.Property_ID).Property_Name;
                    res.Add(propertyName, tmp);

                }
            }
            return res;
        }

        public string GetCategoryBySubCategory(string subCategory)
        {
            var subCategories = uow.SubCategory.GetAll();
            int? CategoryId = 0;
            foreach (var item in subCategories)
            {
                if (item.SubCategory_Name == subCategory)
                {
                    CategoryId = item.Category_ID;
                }
            }
            if (CategoryId == null)
            {
                return "";
            }
            else
            {
                int CategoryIdValue = CategoryId.Value;
                string CategoryName = uow.Category.GetByID(CategoryIdValue).Category_Name;
                return CategoryName;
            }
        }

        public List<Product> GetProductsBySubCategory(string subCategory)
        {
            List<Product> res = new List<Product>();
            var products = uow.Product.GetAll();
            foreach (var item in products)
            {
                if (item.SubCategory.SubCategory_Name == subCategory)
                {
                    res.Add(item);
                }
            }
            return res;
        }
    }
}
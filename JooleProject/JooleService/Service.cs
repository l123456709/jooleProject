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
/*

        public boolean LoginValidation(string username, string password)
        {
            var allusers = uow.User.GetAll();

            foreach (var item in allusers)
            {
                if (item.name == username && item.password == password)
                {
                    return true;
                }
            }

            return false;
        }*/

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

        public Dictionary<string, Dictionary<string, string>> GetDetailsByProductId(int productId)
        {
            Dictionary<string, Dictionary<string, string>> res = new Dictionary<string, Dictionary<string, string>>();
            var product = uow.Product.GetByID(productId);

            Dictionary<string, string> productDescription = new Dictionary<string, string>();
            productDescription.Add("Product Image", product.Product_Image);
            productDescription.Add("Product Name", product.Product_Name);
            productDescription.Add("Series", product.Series);
            productDescription.Add("Model", product.Model);
            productDescription.Add("Model Year", product.Model_Year);
            productDescription.Add("Series Info", product.Series_Info);
            res.Add("DESCRIPTION", productDescription);

            Dictionary<string, string> productType = new Dictionary<string, string>();
            Dictionary<string, string> productTechSpec = new Dictionary<string, string>();
            var propertyValues = uow.PropertyValue.GetAll();
            foreach (var item in propertyValues)
            {
                if (item.Product_ID == productId)
                {
                    if (item.Property.IsType.Value)
                    {
                        productType.Add(item.Property.Property_Name, item.Value);
                    }
                    if (item.Property.IsTechSpec.Value)
                    {
                        productTechSpec.Add(item.Property.Property_Name, item.Value);
                    }
                }
            }

            res.Add("TYPE", productType);
            res.Add("TECHNICAL SPECIFICATIONS", productTechSpec);

            return res;
        }

        public List<Product> GetProductsByTechSpecFilter(List<int> fltVal, string subCategory)
        {
            List<Product> res = new List<Product>();
            var products = uow.Product.GetAll();
            var properties = uow.TechSpecFilter.GetAll();
            List<int> allPropertyId = new List<int>();
            int length = fltVal.Count() / 2;
            
            /*            foreach (var item in properties)
                        {
                            if (item.SubCategory.SubCategory_Name == subCategory)
                            {
                                allPropertyId.Add(item.Property_ID);
                            }
                        }
            */
            foreach (var item in products)
            {

                if (item.SubCategory.SubCategory_Name == subCategory)
                {
                    bool flag = true;
                    int i = 0;
                    foreach (var pVal in item.PropertyValues)
                    {   
                        if (i >= length)
                        {
                            break;
                        }

                        if (pVal.Property.IsTechSpec == true)
                        {
                            int x = Int32.Parse(pVal.Value);
                            int a = i * 2;
                            int min = fltVal[a];
                            int max = fltVal[a + 1];
                            if (x > max || x < min)
                            {
                                flag = false;
                            }
                            i++;
                        }
                        
                    }
                    if (flag == true)
                    {
                        res.Add(item);
                    }
                }
            }
            return res;
        }
    }
}
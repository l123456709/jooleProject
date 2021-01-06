using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleProject.Models;

namespace JooleProject.ViewModels
{
    public class CategoryVM
    {
        public Category Category = new Category();
        public List<Category> CategoryList = new List<Category>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleProject.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Categories = new List<SelectListItem>();
            this.SubCategories = new List<SelectListItem>();
        }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> SubCategories { get; set; }

        public int Category_ID { get; set; }
        public int SubCategory_ID { get; set; }
    }
}
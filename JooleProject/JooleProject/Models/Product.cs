using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleProject.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        public Nullable<int> SubCategory_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Model_Year { get; set; }
        public string Series_Info { get; set; }
    }
}
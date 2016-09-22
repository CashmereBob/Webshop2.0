using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class ProductObject
    {
        public int productID { get; set; }
        public string name { get; set; }
        public decimal description { get; set; }
        public decimal priceB2C { get; set; }
        public decimal priceB2B { get; set; }
        public string brandName { get; set; }
        public string category { get; set; }
        public string imgURL { get; set; }
        public Dictionary<string, List<string>> attribut { get; set; }
        public int quantity { get; set; }
        public string artNr { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class OrderObject
    {
        public UserObject usr = new UserObject();
        public int userID { get; set; }
        public int orderId { get; set; }
        public int priceGroup { get; set; }
        public string company { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adress { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }

        public string telephone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }

        public string date { get; set; }
        public List<ProductObject> products = new List<ProductObject>();

        public string carrier { get; set; }
        public string carrierService { get; set; }
        public decimal carrierPrice { get; set; }

        public string payment { get; set; }
        public string paymentService { get; set; }
        public decimal paymentPrice { get; set; }

        public decimal sum = 0M;

        public decimal CalculatePrice()
        {
            decimal sum = -1;

            foreach (ProductObject product in products)
            {
                if (priceGroup == 2)
                {
                    sum += product.priceB2B * product.quantity;
                }
                if (priceGroup == 1)
                {
                    sum += product.priceB2C * product.quantity;
                }

            }

            sum += paymentPrice;
            sum += carrierPrice;

            return sum;
        }

        public void AddProduct(ProductObject prod)
        {
            this.products.Add(prod);
        }
    }
}
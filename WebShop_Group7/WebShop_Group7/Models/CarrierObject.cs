using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class CarrierObject
    {
        public int carrierId { get; set; }
        public string carrier { get; set; }
        public string service { get; set; }
        public decimal price { get; set; }
    }
}
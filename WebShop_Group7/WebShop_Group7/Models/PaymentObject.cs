using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class PaymentObject
    {

        public int paymentId { get; set; }
        public string payment { get; set; }
        public string service { get; set; }
        public decimal price { get; set; }
    }
}
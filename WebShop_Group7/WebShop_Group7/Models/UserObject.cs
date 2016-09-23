using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_Group7.Models
{
    public class UserObject
    {
        public int userId { get; set; }
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
        public bool admin { get; set; }
        public string password { get; set; }
        public string salt { get; set; }

    }
}
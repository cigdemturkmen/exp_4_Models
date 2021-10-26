using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public int MyProperty { get; set; }

        public int CategoryId { get; set; }
    }
}
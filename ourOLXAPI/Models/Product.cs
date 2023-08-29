using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class ProductResponse
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public List<Product> Result { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

    }

}

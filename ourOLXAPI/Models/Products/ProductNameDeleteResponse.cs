using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class ProductNameDeleteResponse
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public string DeletedProductName { get; set; }
    }
}

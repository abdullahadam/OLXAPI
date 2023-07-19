using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class ProductCategoryDeleteResponse
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public string DeletedProductCategory { get; set; }
    }
}

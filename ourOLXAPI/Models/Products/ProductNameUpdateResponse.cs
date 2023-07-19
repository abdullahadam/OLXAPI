using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class ProductNameUpdateResponse
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public string UpdatedProductCategory { get; set; }
    }
}

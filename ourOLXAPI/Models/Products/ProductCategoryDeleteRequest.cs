using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class ProductCategoryDeleteRequest
    {
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string DeletedProductCategory { get; set; }

    }
}

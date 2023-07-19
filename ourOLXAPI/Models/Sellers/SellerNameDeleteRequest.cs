using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class SellerNameDeleteRequest
    {
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public string DeletedSellerName { get; set; }
    }
}

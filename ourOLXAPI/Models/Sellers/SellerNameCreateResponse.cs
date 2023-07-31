using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class SellerNameCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<Seller> Result { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class SellerNameCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
       
    }
}

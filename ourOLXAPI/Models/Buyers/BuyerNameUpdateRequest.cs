using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class BuyerNameUpdateRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }
    }
}

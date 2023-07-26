using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class BuyerResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<Buyer> Result { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public interface ISellerService
    {
        SellerNameResponse GetSellerName(string fileLocation);

        SellerNameCreateResponse CreateSellerName(SellerNameCreateRequest request);

        SellerNameDeleteResponse DeleteSellerName(SellerNameDeleteRequest request);
        SellerNameUpdateResponse UpdateSellerName(SellerNameUpdateRequest request);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public interface IBuyerService
    {
        BuyerResponse GetBuyerName();
        BuyerNameCreateResponse CreateBuyerName(BuyerNameCreateRequest request);
        BuyerNameDeleteResponse DeleteBuyerName(BuyerNameDeleteRequest request);
        BuyerNameUpdateResponse UpdateBuyerName(BuyerNameUpdateRequest request);




    }
}



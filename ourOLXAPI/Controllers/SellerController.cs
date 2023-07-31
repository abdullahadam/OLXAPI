using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ourOLXAPI.Models;
using ourOLXAPI.Services;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : Controller
    {

        private readonly ILogger<SellerController> _logger;
        private readonly ISellerService _sellerService;

        public SellerController(ILogger<SellerController> logger, ISellerService sellerService)
        {
            _logger = logger;
            this._sellerService = sellerService;
        }

        [HttpGet]
        [Route("getsellername", Name = "GetSellerName")]
        public IActionResult GetSellerName()
        {

            var response = _sellerService.GetSellerName();

            return Ok(response);

        }


        [HttpPost]
        [Route("createsellername", Name = "CreateSellerName")]
        public IActionResult CreateSellerName([FromBody] SellerNameCreateRequest request)
        {
            var response = _sellerService.CreateSellerName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("deletesellername", Name = "DeleteSellerName")]
        public IActionResult DeleteSellerName([FromBody] SellerNameDeleteRequest request)
        {
            var response = _sellerService.DeleteSellerName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updatesellername", Name = "UpdateSellerName")]
        public IActionResult UpdateSellerName([FromBody] SellerNameUpdateRequest request)
        {
            var response = _sellerService.UpdateSellerName(request);

            return Ok(response);

        }


    }
}


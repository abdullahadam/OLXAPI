using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ourOLXAPI.Models;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyerController : Controller
    {
       
        private readonly ILogger<BuyerController> _logger;
        private readonly IBuyerService _BuyerService;



        public BuyerController(ILogger<BuyerController> logger, IBuyerService BuyerService)
        {
            _logger = logger;
            this._BuyerService = BuyerService;
        }
        

        [HttpGet]
        [Route("getbuyername", Name = "GetBuyerName")]
        public IActionResult GetBuyerName([Required] string fileLocation)
        {

            var response = _BuyerService.GetBuyerName(fileLocation);

            return Ok(response);

        }

        [HttpPost]
        [Route("createbuyername", Name = "CreateBuyerName")]
        public IActionResult CreateBuyerName([FromBody] BuyerNameCreateRequest request)
        {
            var response = _BuyerService.CreateBuyerName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("deletebuyername", Name = "DeleteBuyerName")]
        public IActionResult DeleteBuyerName([FromBody] BuyerNameDeleteRequest request)
        {
            var response = _BuyerService.DeleteBuyerName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updatebuyername", Name = "UpdateBuyerName")]
        public IActionResult UpdateBuyerName([FromBody] BuyerNameUpdateRequest request)
        {
            var response = _BuyerService.UpdateBuyerName(request);

            return Ok(response);

        }


    }
}

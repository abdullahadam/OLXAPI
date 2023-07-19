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
    public class ProductController : Controller
    {

        private readonly ILogger<ProductController>_logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this._productService = productService;
        }

        [HttpGet]
        [Route("getproducttype", Name = "GetProductType")]
        public IActionResult GetProductType([Required] string fileLocation)
        {

            var response = _productService.GetProductTypes(fileLocation);

            return Ok(response);

        }



        [HttpPost]
        [Route("createproducttype", Name = "CreateProductType")]
        public IActionResult CreateProductType([FromBody] ProductTypeCreateRequest request)
        {
            var response = _productService.CreateProductType(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("deleteproducttype", Name = "DeleteProductType")]
        public IActionResult DeleteProductType([FromBody] ProductTypeDeleteRequest request)
        {
            var response = _productService.DeleteProductType(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updateproducttype", Name = "UpdateProductType")]
        public IActionResult UpdateProductType([FromBody] ProductTypeUpdateRequest request)
        {
            var response = _productService.UpdateProductType(request);

            return Ok(response);

        }



        [HttpGet]
        [Route("getproductcategory", Name = "GetProductCategory")]
        public IActionResult GetProductCategory([Required] string fileLocation)
        {

            var response = _productService.GetProductCategory(fileLocation);
            

            return Ok(response);

        }


        [HttpPost]
        [Route("createproductcategory", Name = "CreateProductCategory")]
        public IActionResult CreateProductCategory([FromBody] ProductCategoryCreateRequest request)
        {
            var response = _productService.CreateProductCategory(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("deleteproductCategory", Name = "DeleteProductCategory")]
        public IActionResult DeleteProductCategory([FromBody] ProductCategoryDeleteRequest request)
        {
            var response = _productService.DeleteProductCategory(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updateproductcategory", Name = "UpdateProductCategory")]
        public IActionResult UpdateProductCategory([FromBody] ProductCategoryUpdateRequest request)
        {
            var response = _productService.UpdateProductCategory(request);

            return Ok(response);

        }



        [HttpGet]
        [Route("getproductname", Name = "GetProductName")]
        public IActionResult GetProductName([Required] string fileLocation)
        {

            var response = _productService.GetProductName(fileLocation);

            return Ok(response);

        }

        [HttpPost]
        [Route("createproductname", Name = "CreateProductName")]
        public IActionResult CreateProductName([FromBody] ProductNameCreateRequest request)
        {
            var response = _productService.CreateProductName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("deleteproductname", Name = "DeleteProductName")]
        public IActionResult DeleteProductName([FromBody] ProductNameDeleteRequest request)
        {
            var response = _productService.DeleteProductName(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updateproductname", Name = "UpdateProductName")]
        public IActionResult UpdateProductName([FromBody] ProductNameUpdateRequest request)
        {
            var response = _productService.UpdateProductName(request);

            return Ok(response);

        }





    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public interface IProductService
    {
        ProducttTypeResponse GetProductTypes(string fileLocation);
        ProductTypeCreateResponse CreateProductType(ProductTypeCreateRequest request);
        ProductTypeDeleteResponse DeleteProductType(ProductTypeDeleteRequest request);
        ProductTypeUpdateResponse UpdateProductType(ProductTypeUpdateRequest request);




        ProductCategoryResponse GetProductCategory(string fileLocation);
        ProductCategoryCreateResponse CreateProductCategory(ProductCategoryCreateRequest request);
        ProductCategoryDeleteResponse DeleteProductCategory(ProductCategoryDeleteRequest request);
        ProductCategoryUpdateResponse UpdateProductCategory(ProductCategoryUpdateRequest request);



        ProductNameResponse GetProductName(string fileLocation);
        ProductNameCreateResponse CreateProductName(ProductNameCreateRequest request);
        ProductNameDeleteResponse DeleteProductName(ProductNameDeleteRequest request);
        ProductNameUpdateResponse UpdateProductName(ProductNameUpdateRequest request);



    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Services
{
    public class ProductService : IProductService
    {

        public ProducttTypeResponse GetProductTypes(string fileLocation)
        {
            var productTypeLocation = fileLocation;
            var response = new ProducttTypeResponse();
            response.Result = new List<ProductType>();


            try
            {
                foreach (string file in Directory.EnumerateFiles(productTypeLocation, "*.txt"))
                {
                    if (file.Contains("ProductType"))
                    {

                        StreamReader reader = new StreamReader(file);
                        string readData = reader.ReadToEnd();
                        string separator = "\r\n";
                        var ReadRecordList = new List<string>(readData.Split(separator));
                        ReadRecordList = ReadRecordList.Skip(1).ToList();
                        ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                        //ReadRecordList.ForEach(x => productTypeFromFile.Add(x));
                        foreach (var productTypeFromFile in ReadRecordList)
                        {
                            var productType = new ProductType();
                            productType.Name = productTypeFromFile;
                            response.Result.Add(productType);
                        }
                        reader.Close();
                    }
                }

                response.Issuccess = true;
                response.Message = "Success";
            }

            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = ex.Message.ToString();
            }

            return response;

        }

        public ProductTypeCreateResponse CreateProductType(ProductTypeCreateRequest request)
        {

            var response = new ProductTypeCreateResponse();


            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Add(request.NewProductType);
                   // File.WriteAllLines(request.FileLocation, ReadRecordList);


                    string fileRecord = $"{request.NewProductType}";
                    string[] fileOutput =
                {

                    fileRecord 
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(Environment.NewLine + fileOutput); ;


                        response.Message = "New ProductType created successfully";
                        response.Issuccess = true;
                      

                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }

        public ProductTypeDeleteResponse DeleteProductType (ProductTypeDeleteRequest request)
        {
            var response = new ProductTypeDeleteResponse();

            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Remove(request.DeletedProductType);
                    //File.WriteAllLines(request.FileLocation, ReadRecordList);

                    string fileRecord = $"{request.DeletedProductType}";
                    string[] fileOutput =
               {
                    fileRecord = null
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(fileOutput); 


                        response.Message = "ProductType deleted successfully";
                        response.Issuccess = true;

                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }

        public ProductTypeUpdateResponse UpdateProductType(ProductTypeUpdateRequest request)
        {
            var response = new ProductTypeUpdateResponse();

            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                  
                   
                }
            }



                    return response;
        }





        public ProductCategoryResponse GetProductCategory(string fileLocation)
        {
            var productCategoryLocation = fileLocation;
            var response = new ProductCategoryResponse();
            response.Result = new List<ProductCategory>();


            try
            {
                foreach (string file in Directory.EnumerateFiles(productCategoryLocation, "*.txt"))
                {
                    if (file.Contains("ProductCategory"))
                    {
                        StreamReader reader = new StreamReader(file);
                        string readData = reader.ReadToEnd();
                        string separator = "\r\n";
                        var ReadRecordList = new List<string>(readData.Split(separator));
                        ReadRecordList = ReadRecordList.Skip(1).ToList();
                        ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                        foreach (var productCategoryFromFile in ReadRecordList)
                        {
                            var productCategory = new ProductCategory();
                            productCategory.Name = productCategoryFromFile;
                            response.Result.Add(productCategory);
                        }
                        reader.Close();
                    }
                }
                response.Issuccess = true;
                response.Message = "ProductCategory found succesfully";
            }


            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = ex.Message.ToString();
            }

          

            return response;

        }

        public ProductCategoryCreateResponse CreateProductCategory(ProductCategoryCreateRequest request)
        {

            var response = new ProductCategoryCreateResponse();


            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Add(request.NewProductCategory);
                    // File.WriteAllLines(request.FileLocation, ReadRecordList);


                    string fileRecord = $"{request.NewProductCategory}";
                    string[] fileOutput =
                {

                    fileRecord
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(Environment.NewLine + fileOutput); ;


                        response.Message = "New ProductCategory created successfully";
                        response.Issuccess = true;


                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }

        public ProductCategoryDeleteResponse DeleteProductCategory(ProductCategoryDeleteRequest request)
        {
            var response = new ProductCategoryDeleteResponse();

            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Remove(request.DeletedProductCategory);
                    //File.WriteAllLines(request.FileLocation, ReadRecordList);

                    string fileRecord = $"{request.DeletedProductCategory}";
                    string[] fileOutput =
               {
                    fileRecord = null
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(fileOutput);


                        response.Message = "ProductCategory deleted successfully";
                        response.Issuccess = true;

                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }

        public ProductCategoryUpdateResponse UpdateProductCategory(ProductCategoryUpdateRequest request)
        {
            var response = new ProductCategoryUpdateResponse();



            return response;
        }



        public ProductNameResponse GetProductName(string fileLocation)
        {
            var productNameLocation = fileLocation;
            var response = new ProductNameResponse();
            response.Result = new List<ProductName>();

            try
            {
                foreach (string file in Directory.EnumerateFiles(productNameLocation, "*.txt"))
                {
                    if (file.Contains("ProductName"))
                    {
                        StreamReader reader = new StreamReader(file);
                        string readData = reader.ReadToEnd();
                        string separator = "\r\n";
                        var ReadRecordList = new List<string>(readData.Split(separator));
                        ReadRecordList = ReadRecordList.Skip(1).ToList();
                        ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                        foreach (var productNameFromFile in ReadRecordList)
                        {
                            var productName = new ProductName();
                            productName.Name = productNameFromFile;
                            response.Result.Add(productName);
                        }
                        reader.Close();
                    }
                }
                response.Issuccess = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();
            }

            return response;

        }


        public ProductNameCreateResponse CreateProductName(ProductNameCreateRequest request)
        {

            var response = new ProductNameCreateResponse();


            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Add(request.NewProductName);
                    // File.WriteAllLines(request.FileLocation, ReadRecordList);


                    string fileRecord = $"{request.NewProductName}";
                    string[] fileOutput =
                {

                    fileRecord
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(Environment.NewLine + fileOutput); ;


                        response.Message = "New ProductName created successfully";
                        response.Issuccess = true;


                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }


        public ProductNameDeleteResponse DeleteProductName(ProductNameDeleteRequest request)
        {
            var response = new ProductNameDeleteResponse();

            foreach (string file in Directory.EnumerateFiles(request.FileLocation, "*.txt"))
            {
                if (file.Contains(request.FileName))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    ReadRecordList.Remove(request.DeletedProductName);
                    //File.WriteAllLines(request.FileLocation, ReadRecordList);
                      
                    string fileRecord = $"{request.DeletedProductName}";
                    string[] fileOutput =
               {
                    fileRecord = null
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(fileOutput);


                        response.Message = "ProductName deleted successfully";
                        response.Issuccess = true;

                    }
                    catch (Exception ex)
                    {

                        response.Message = ex.Message.ToString();
                        return response;
                    }


                    reader.Close();
                }
            }

            return response;
        }

        public ProductNameUpdateResponse UpdateProductName(ProductNameUpdateRequest request)
        {
            var response = new ProductNameUpdateResponse();



            return response;
        }





    }
}

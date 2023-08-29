using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ourOLXAPI.Models;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _appSettings;

        public ProductService(
            IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }

        public ProducttTypeResponse GetProductTypes()
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new ProducttTypeResponse();


            response.Result = new List<ProductType>();


            string query = "SELECT * FROM dbo.ProductType";
            //string query = "insert into dbo.Person values(7,'Ahemds','dodo','9888701234099','1986-01-01',44,'Male')";
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var productToAdd = new ProductType();
                                productToAdd.Id = Convert.ToInt32($"{reader.GetInt32(0).ToString()}");
                                productToAdd.ProductTypeDescription = $"{reader.GetString(1).ToString()}";
                               
                                response.Result.Add(productToAdd);
                                // Do something with the retrieved data
                            }
                        }
                    }
                    connection.Close();
                }
                response.Issuccess = true;
                response.Message = "Successfully retrieved data";
            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = $"error message: {ex.Message.ToString()}";
            }





            return response;

        }

        public ProductTypeCreateResponse CreateProductType(ProductTypeCreateRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new ProductTypeCreateResponse();






            string query = $"insert into dbo.ProductType values({request.Id},'{request.ProductTypeDescription}')";
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
           
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    try 
                    {
                    connection.Close();
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                response.Message = $"{request.Id} {request.ProductTypeDescription} was added successfully.";
                                response.Issuccess = true;

                            }
                        }
                        connection.Close();
                    }
                    catch (Exception exx)
                    {
                        response.Message = $"Failure to upload {request.Id} {request.ProductTypeDescription} , reason for failure : {exx.Message.ToString()} ";
                        response.Issuccess = false;
                    connection.Close();
                    }
                    
                }

            return response;


        }

        public ProductTypeDeleteResponse DeleteProductType (ProductTypeDeleteRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new ProductTypeDeleteResponse();






            string query = $"delete from dbo.ProductType where Id = {request.Id}";
            //string query = "insert into dbo.Person values(7,'Ahemds','dodo','9888701234099','1986-01-01',44,'Male')";
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            response.Message = $"Product id ref:{request} has been deleted successfully.";
                            response.Issuccess = true;

                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exx)
            {
                response.Message = $"Failure to delete product id ref:{request} , reason for failure : {exx.Message.ToString()} ";
                response.Issuccess = false;

            }

            return response;
        }

        public ProductTypeUpdateResponse UpdateProductType(ProductTypeUpdateRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new ProductTypeUpdateResponse();





            string query = $"update dbo.ProductType set ProductTypeDescription = '{request.ProductTypeDescription}' where Id ={request.Id}";

            //string query = "insert into dbo.Person values(7,'Ahemds','dodo','9888701234099','1986-01-01',44,'Male')";
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            response.Issuccess = true;
                            response.Message = "Update Succesfull.";
                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = $"error message: {ex.Message.ToString()}";
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

        public ProductResponse GetProduct(string fileLocation)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new ProductResponse();


            response.Result = new List<Product>();


            string query = "SELECT * FROM dbo.Product";
            //string query = "insert into dbo.Person values(7,'Ahemds','dodo','9888701234099','1986-01-01',44,'Male')";
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var productToAdd = new Product();
                                productToAdd.Id = Convert.ToInt32($"{reader.GetInt32(0).ToString()}");
                                productToAdd.ProductName= $"{reader.GetString(1).ToString()}";
                                productToAdd.ProductType = $"{reader.GetString(2).ToString()}";

                                response.Result.Add(productToAdd);
                                // Do something with the retrieved data
                            }
                        }
                    }
                    connection.Close();
                }
                response.Issuccess = true;
                response.Message = "Successfully retrieved data";
            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = $"error message: {ex.Message.ToString()}";
            }





            return response;

        }





    }
}

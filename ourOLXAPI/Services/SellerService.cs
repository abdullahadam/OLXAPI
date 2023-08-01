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
    public class SellerService : ISellerService
    {

        private readonly IConfiguration _appSettings;

        public SellerService(
            IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }


        public SellerNameResponse GetSellerName()
        {

            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new SellerNameResponse();

            response.Result = new List<Seller>();





            string query = "SELECT * FROM dbo.SellerTable";
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
                                var sellerToAdd = new Seller();
                                sellerToAdd.Id = Convert.ToInt32($"{reader.GetInt32(0).ToString()}");
                                sellerToAdd.Name = $"{reader.GetString(1).Replace(" ", string.Empty)}";
                                sellerToAdd.Surname = $"{reader.GetString(2).Replace(" ", string.Empty)}"; 
                                sellerToAdd.DOB = reader.GetString(3);
                                sellerToAdd.Age = reader.GetInt32(4);
                                sellerToAdd.Gender = reader.GetString(5).Replace(" ", string.Empty);
                                response.Result.Add(sellerToAdd);
                             
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
        public SellerNameCreateResponse CreateSellerName(SellerNameCreateRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new SellerNameCreateResponse();



            response.Result = new List<Seller>();



            string query = $"insert into dbo.SellerTable values({request.Id},'{request.Name}','{request.Surname}','{request.DOB}',{request.Age},'{request.Gender}')";
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
                            response.Message = $"{request.Name} {request.Surname} was added successfully.";
                            response.IsSuccess = true;

                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                response.Message = $"Failure to upload {request.Name} {request.Surname} , reason for failure : {ex.Message.ToString()} ";
                response.IsSuccess = false;
            }




            return response;
        }


        public SellerNameDeleteResponse DeleteSellerName(int request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new SellerNameDeleteResponse();






            string query = $"delete from dbo.SellerTable where Id = {request}";
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
                            response.Message = $"seller id ref:{request} has been deleted successfully.";
                            response.Issuccess = true;

                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exx)
            {
                response.Message = $"Failure to delete seller id ref:{request} , reason for failure : {exx.Message.ToString()} ";
                response.Issuccess = false;

            }

            return response;
        }

        public SellerNameUpdateResponse UpdateSellerName(SellerNameUpdateRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new SellerNameUpdateResponse();





            string query = $"update dbo.SellerTable set Name = '{request.Name}',Surname = '{request.Surname}' where Id = '{request.Id}'";

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
    }
}

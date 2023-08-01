using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public class BuyerService : IBuyerService
    {

        private readonly IConfiguration _appSettings;

        public BuyerService(
            IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }
        public BuyerResponse GetBuyerName()
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new BuyerResponse();


            response.Result = new List<Buyer>();


            string query = "SELECT * FROM dbo.BuyerTable";
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
                                var buyerToAdd = new Buyer();
                                buyerToAdd.Id = Convert.ToInt32($"{reader.GetInt32(0).ToString()}");
                                buyerToAdd.Name = $"{reader.GetString(1).Replace(" ", string.Empty)} {reader.GetString(2).Replace(" ", string.Empty)}";
                                buyerToAdd.DOB = reader.GetString(3);
                                buyerToAdd.Age = reader.GetInt32(4);
                                buyerToAdd.Gender = reader.GetString(5).Replace(" ", string.Empty);
                                response.Result.Add(buyerToAdd);
                                // Do something with the retrieved data
                            }
                        }
                    }
                    connection.Close();
                }
                response.IsSuccess = true;
                response.Message = "Successfully retrieved data";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"error message: {ex.Message.ToString()}";
            }
            




            return response;

        }

        public BuyerNameCreateResponse CreateBuyerName(BuyerNameCreateRequest request)
        {

            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new BuyerNameCreateResponse();






            string query = $"insert into dbo.BuyerTable values({request.Id},'{request.Name}','{request.Surname}','{request.DOB}',{request.Age},'{request.Gender}')";
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
                            response.Issuccess = true;

                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                response.Message = $"Failure to upload {request.Name} {request.Surname} , reason for failure : {ex.Message.ToString()} ";
                response.Issuccess = false;
            }




            return response;
        }

        public BuyerNameDeleteResponse DeleteBuyerName(BuyerNameDeleteRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new BuyerNameDeleteResponse();



           


            string query = $"delete from dbo.BuyerTable where Id = {request.Id}";
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
                            response.Message = $"{request.Name} has been deleted successfully.";
                            response.Issuccess = true;

                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exx)
            {
                response.Message = $"Failure to delete {request.Name} , reason for failure : {exx.Message.ToString()} ";
                response.Issuccess = false;

            }

            return response;
        }

        public BuyerNameUpdateResponse UpdateBuyerName(BuyerNameUpdateRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new BuyerNameUpdateResponse();



         

            string query = $"update dbo.BuyerTable set Name = '{request.Name}',Surname = '{request.Surname}' where Id = '{request.Id}'";

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
                            response.Message = "Successfully retrieved data";
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

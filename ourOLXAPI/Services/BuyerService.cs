﻿using System;
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

            var response = new BuyerNameCreateResponse();


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
                    ReadRecordList.Add(request.NewBuyerName);
                    // File.WriteAllLines(request.FileLocation, ReadRecordList);


                    string fileRecord = $"{request.NewBuyerName}";
                    string[] fileOutput =
                {

                    fileRecord
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(Environment.NewLine + fileOutput); ;


                        response.Message = "New BuyerName created successfully";
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

        public BuyerNameDeleteResponse DeleteBuyerName(BuyerNameDeleteRequest request)
        {
            var response = new BuyerNameDeleteResponse();

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
                    ReadRecordList.Remove(request.DeletedBuyerName);
                    //File.WriteAllLines(request.FileLocation, ReadRecordList);

                    string fileRecord = $"{request.DeletedBuyerName}";
                    string[] fileOutput =
               {
                    fileRecord = null
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(fileOutput);


                        response.Message = "BuyerName deleted successfully";
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

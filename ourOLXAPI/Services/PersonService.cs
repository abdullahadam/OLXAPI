﻿using System;
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
    public class PersonService : IPersonService
    {
        private readonly IConfiguration _appSettings;
        private readonly INotificationsService _notificationsService;

        public PersonService(
            IConfiguration appSettings , INotificationsService notificationsService)
        {
            _appSettings = appSettings;
            _notificationsService = notificationsService;
        }
        public PersonResponse GetAllPersons()
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var readFromSQL = Convert.ToInt32(_appSettings.GetSection("ReadFromSQL").Value);
            var response = new PersonResponse();

            response.Result = new List<Person>();

            string query = "SELECT * FROM dbo.Person";
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
                            var personToAdd = new Person();
                            while (reader.Read())
                            {
                                personToAdd.IDNumber = reader.GetString(3);
                                personToAdd.Name = $"{reader.GetString(1)} {reader.GetString(2)}";
                                personToAdd.DateOfBirth = reader.GetString(4);
                                personToAdd.Age = Convert.ToInt32(reader.GetString(5));
                                personToAdd.Gender = reader.GetString(6);
                                response.Result.Add(personToAdd);
                                // Do something with the retrieved data
                                response.IsSuccess = true;
                            }
                        }
                    }
                    if (response.IsSuccess== true)
                    {
                        var slackResponse = _notificationsService.SendSlackMessege("#notifications", "Succesfully retreived all persons");
                     
                    }
                    //call slackbot
                    connection.Close();
                }
            }
            catch  (Exception exx)
            {
                var slackResponse = _notificationsService.SendSlackMessege("#notifications", $"failed to get all persons, error is: {exx.Message.ToString()}");
                response.Message = $"Failure to get person from database {sqlConnectionString} , reason for failure : {exx.Message.ToString()} ";
                response.IsSuccess = false;
            }
            




            return response;
        }

        public PersonResponse CreateAllPersons(CreatePersonRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new PersonResponse();



            response.Result = new List<Person>();



            string query = $"insert into dbo.Person values({request.Id},'{request.Name}','{request.SurName}','{request.IDNumber}','{request.DateOfBirth}',{request.Age},'{request.Gender}')";
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
                            response.Message = $"{request.Name} {request.SurName} was added successfully.";
                            response.IsSuccess = true;

                        }
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                response.Message = $"Failure to upload {request.Name} {request.SurName} , reason for failure : {ex.Message.ToString()} ";
                response.IsSuccess = false;
            }




            return response;
        }

        public PersonResponse UpdateAllPersons( FieldsToUpdate request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;
            var response = new PersonResponse();
            response.Result = new List<Person>();

            string updateQuery = "UPDATE dbo.Person SET FirstName = @FirstName, SurName = @SurName, IdNumber = @IdNumber, DateOfBirth = @DateOfBirth, Age = @Age, Gender = @Gender WHERE Id = @Id";

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {



                        command.Parameters.AddWithValue("@Name", request.FirstName);
                        command.Parameters.AddWithValue("@SurName", request.Surname);
                        command.Parameters.AddWithValue("@IDNumber", request.IdNumber);
                        command.Parameters.AddWithValue("@DateOfBirth", request.DateOfBirth);
                        command.Parameters.AddWithValue("@Age", request.Age);
                        command.Parameters.AddWithValue("@Gender", request.Gender);
                        command.Parameters.AddWithValue("@Id", request.Id);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();

                }
            }
            catch (Exception exx)
            {
                response.Message = $"Failure to upload {request.FirstName} {request.Surname} , reason for failure : {exx.Message.ToString()} ";
                response.IsSuccess = false;
            }
            

            return response;
        }
        public PersonResponse DeleteAllPersons(DeletePersonRequest request)
        {
            var sqlConnectionString = _appSettings.GetSection("SQLConnectionString").Value;

            var response = new PersonResponse();



            response.Result = new List<Person>();


            string query = $"delete from dbo.Person where Id = {request.Id}";
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
                            response.Message = $"{request.Id} has been deleted successfully.";
                            response.IsSuccess = true;

                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exx)
            {
                response.Message = $"Failure to delete {request.Id} , reason for failure : {exx.Message.ToString()} ";
                response.IsSuccess = false;

            }
            
            return response;
        }

    }

}


    
 //   }




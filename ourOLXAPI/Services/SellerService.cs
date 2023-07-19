using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Services
{
    public class SellerService : ISellerService
    {
        public SellerNameResponse GetSellerName(string fileLocation)
        {
            var sellerNameLocation = fileLocation;
            var response = new SellerNameResponse();
            response.Result = new List<SellerName>();

            foreach (string file in Directory.EnumerateFiles(sellerNameLocation, "*.txt"))
            {
                if (file.Contains("SellerName"))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    foreach (var SellerNameFromFile in ReadRecordList)
                    {
                        var SellerName = new SellerName();
                        SellerName.Name = SellerNameFromFile;
                        response.Result.Add(SellerName);
                    }
                    reader.Close();
                }

            }
            return response;
        }
        public SellerNameCreateResponse CreateSellerName(SellerNameCreateRequest request)
        {

            var response = new SellerNameCreateResponse();


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
                    ReadRecordList.Add(request.NewSellerName);
                    // File.WriteAllLines(request.FileLocation, ReadRecordList);


                    string fileRecord = $"{request.NewSellerName}";
                    string[] fileOutput =
                {

                    fileRecord
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(Environment.NewLine + fileOutput); ;


                        response.Message = "New SellerName created successfully";
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


        public SellerNameDeleteResponse DeleteSellerName(SellerNameDeleteRequest request)
        {
            var response = new SellerNameDeleteResponse();

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
                    ReadRecordList.Remove(request.DeletedSellerName);
                    //File.WriteAllLines(request.FileLocation, ReadRecordList);

                    string fileRecord = $"{request.DeletedSellerName}";
                    string[] fileOutput =
               {
                    fileRecord = null
                };

                    try
                    {
                        using (var writer = File.AppendText(request.FileLocation))
                            writer.Write(fileOutput);


                        response.Message = "Sellername deleted successfully";
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

        public SellerNameUpdateResponse UpdateSellerName(SellerNameUpdateRequest request)
        {
            var response = new SellerNameUpdateResponse();

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
    }
}

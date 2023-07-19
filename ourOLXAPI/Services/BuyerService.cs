using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public class BuyerService : IBuyerService
    {
        public BuyerNameResponse GetBuyerName(string fileLocation)
        {
            var buyerNameLocation = fileLocation;
            var response = new BuyerNameResponse();
            response.Result = new List<BuyerName>();

            foreach (string file in Directory.EnumerateFiles(buyerNameLocation, "*.txt"))
            {
                if (file.Contains("BuyerName"))
                {
                    StreamReader reader = new StreamReader(file);
                    string readData = reader.ReadToEnd();
                    string separator = "\r\n";
                    var ReadRecordList = new List<string>(readData.Split(separator));
                    ReadRecordList = ReadRecordList.Skip(1).ToList();
                    ReadRecordList = ReadRecordList.Where(x => x.Length > 0).ToList();
                    foreach (var BuyerNameFromFile in ReadRecordList)
                    {
                        var BuyerName = new BuyerName();
                        BuyerName.Name = BuyerNameFromFile;
                        response.Result.Add(BuyerName);
                    }
                    reader.Close();
                }
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
            var response = new BuyerNameUpdateResponse();

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

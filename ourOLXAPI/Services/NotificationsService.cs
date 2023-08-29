using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ourOLXAPI.Models.SlackNotifications;
using ourOLXAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ourOLXAPI.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly IConfiguration _appSettings;

        public NotificationsService(
            IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<SlackNotifcationResponse> SendSlackMessege(string channel, string message)
        {
            var response = new SlackNotifcationResponse();
            string botToken = _appSettings.GetSection("SlackBotToken").Value;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://slack.com/api/chat.postMessage";
                    var data = new
                    {
                        token = botToken,
                        channel = channel,
                        text = message
                    };
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {botToken}");

                    var slackResponse = await client.PostAsJsonAsync(apiUrl, data);
                    slackResponse.EnsureSuccessStatusCode();

                    string responseContent = await slackResponse.Content.ReadAsStringAsync();

                    var content = JsonConvert.DeserializeObject<SlackResponse>(responseContent);
                    if (content.Ok)
                    {
                        response.IsSuccess = true;
                        response.Message = $"Sent successfuly to slack channel {channel}";
                    }
                    else
                    {
                        var unsuccessContent = JsonConvert.DeserializeObject<slackErrorResponse>(responseContent);
                        response.IsSuccess = false;
                        response.Message = $"cannot connect to slack, error: {unsuccessContent.error}";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = $"cannot connect to slack, error: {ex.Message.ToString()}";
            }

            

            return response;
        }

    }
}

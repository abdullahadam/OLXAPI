using ourOLXAPI.Models.SlackNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Services.Interfaces
{
    public interface INotificationsService
    {

        Task<SlackNotifcationResponse> SendSlackMessege(string channel, string message);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models.SlackNotifications
{
    public class SlackNotifcationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public slackErrorResponse ErrorResponse { get; set; }
    }

    public class SlackResponse
    {
        public bool Ok { get; set; }
    }
    public class slackErrorResponse
    {
        public bool Ok { get; set; }
        public string error { get; set; }
    }
}

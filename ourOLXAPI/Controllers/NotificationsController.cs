using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : Controller
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {

            _notificationsService = notificationsService;
        }

        [HttpPost]
        [Route("sendSlackMessege", Name = "SendSlackMessege")]
        public async Task<IActionResult> SendSlackMessege(string channel , string messege)
        {

            var response = await _notificationsService.SendSlackMessege( channel, messege);

            return Ok(response);

        }

    }
}

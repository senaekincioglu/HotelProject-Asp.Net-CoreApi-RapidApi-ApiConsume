using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twilio.AspNet.Common;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Options;
using HotelProject.WebApi.Models;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly TwilioSettings _twilioSettings;
        public SmsController(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init("AC3d6851fdf3247aa049fba7ac384c5383", "2800579a14c3725d063a9ac6c9c4522b");
        }
        [HttpPost]
        public async Task<IActionResult> SendSms([FromBody] HotelProject.WebApi.Models.SmsRequest smsRequest)
        {

            var message = await MessageResource.CreateAsync(
            body: smsRequest.Body,
            from: new PhoneNumber("+13204387497"),
            to: new PhoneNumber(smsRequest.To)
            );
            return Ok(message.Sid);
        }
    }
}

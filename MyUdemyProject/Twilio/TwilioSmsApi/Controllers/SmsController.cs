using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Types;
using TwilioSmsApi.Models;

namespace TwilioSmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly TwilioSettings _twilioSettings;
        public SmsController(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
            TwilioClient.Init(_twilioSettings.AccountSid, _twilioSettings.AuthToken);
        }
        [HttpPost]
        public async Task<IActionResult> SendSms([FromBody]SmsRequest smsRequest)
        {
            var message = await MessageResource.CreateAsync(
            body: smsRequest.Body,
            from: new PhoneNumber(_twilioSettings.PhoneNumber),
            to: new PhoneNumber(smsRequest.To)
            );
            return Ok(message.Sid);
        }
    }
}

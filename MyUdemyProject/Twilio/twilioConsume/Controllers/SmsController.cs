using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;

namespace twilioConsume.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ITwilioRestClient _client;

        public SmsController(ITwilioRestClient client)
        {
            _client = client;
        }
        [HttpPost("api/send-sms")]
        public IActionResult SendSms(SmsMessage model)
        {
            var message = MessageResource.Create(
                to: new PhoneNumber(model.To),
                from: new PhoneNumber(model.From,
                Body = model.Message,
                Client = _client;
                
                
                
                )
        }
    }
}

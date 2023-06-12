//using Microsoft.AspNetCore.Mvc;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;

//namespace twilioConsume.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class SendSMSController : ControllerBase
//    {

//        string accountSid = "AC3d6851fdf3247aa049fba7ac384c5383";
//        string authToken = "2800579a14c3725d063a9ac6c9c4522b";


//        [HttpPost]
//        public IActionResult SendText(string phoneNumber)
//        {
//            TwilioClient.Init(accountSid, authToken);
//            var message = MessageResource.Create(


//               body: "Merhaba twilio api deneme",
//               from: new Twilio.Types.PhoneNumber("+18315259256"),//sms in gönderileceği no
//               to: new Twilio.Types.PhoneNumber("+90" + phoneNumber)//alıcı no


//               );
//            return StatusCode(200,new {message=message.Sid});
//        }
    
//    }
//}

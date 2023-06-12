//using Microsoft.AspNetCore.Mvc;
//using Twilio.AspNet.Core;
//using Twilio.TwiML;
//using twilioConsume.Models;

//namespace twilioConsume.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]

//    public class RecieveSMSController : TwilioController
//    {
//        [HttpPost("SendReply")]
//        public TwiMLResult SendReply([FromForm]TwilioSMS request) //sms almak
//        {
//            var response=new MessagingResponse();
//            response.Message("merhaba deneme");
//            return TwiML(response);
//        }
//    }
//}

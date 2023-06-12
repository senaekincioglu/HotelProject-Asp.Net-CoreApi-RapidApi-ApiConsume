namespace twilioConsume.Models
{
    public class TwilioSMS
    {
        //gelen ve bize kimin gönderdiği ve mesajın gövdesi
        public string From { get; set; }
        public string Body { get; set; }
    }
}

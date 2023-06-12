﻿using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage=new MimeMessage();

            //Kimden?
            MailboxAddress mailboxAddress=new MailboxAddress("HotelierAdmin", "ekincioglusena1@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            //Kime?
            MailboxAddress mailboxAddressTo=new MailboxAddress("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            
            //Mesajın İçeriği
            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody=model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //Mail konusus
            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("ekincioglusena1@gmail.com", "gjriulawfxslpjcj");
            client.Send(mimeMessage);
            client.Disconnect(true);

            //Gönderilen Mailin veritabanına kaydedilmesi.
            return View();
        }
    }
}

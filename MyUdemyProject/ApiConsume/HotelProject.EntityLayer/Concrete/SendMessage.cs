using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class SendMessage //Gönderilen Mesaj
    {
        public int SendMessageID { get; set; }

        public string ReceiverName { get; set; }//Alıcı Adı
        public string ReceiverMail { get; set; }//Alıcı Maili
        public string SenderName { get; set; } //Gönderenin adı soyadı
        public string SenderMail { get; set; } //Gönderenin Maili
        public string Title { get; set; }//Başlık
        public string Content { get; set; } //içerik
        public DateTime Date { get; set; }
    }
}

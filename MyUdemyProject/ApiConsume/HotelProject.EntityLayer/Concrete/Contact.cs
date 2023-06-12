using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Contact //İletişim
    {
        public int ContactID { get; set; }
        public string Name { get; set; } //İsim
        public string Mail { get; set; }//Mail
        public string Subject { get; set; }//Konu
        public string Message { get; set; }//Mesaj
        public DateTime Date { get; set; }//Tarih
        //Alttaki iki kısım ilişki için geçerli
        public int MessageCategoryID { get; set; }
        public MessageCategory MessageCategory { get; set; }
    }
}

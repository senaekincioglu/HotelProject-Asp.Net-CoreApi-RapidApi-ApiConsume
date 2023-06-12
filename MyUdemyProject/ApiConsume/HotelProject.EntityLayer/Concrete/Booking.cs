using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public DateTime Checkin { get; set; } //Giriş tarihi
        public DateTime CheckOut { get; set; } //Çıkış Tarihi
        public string AdultCount { get; set; } //Yetişkin Sayısı
        public string ChildCount { get; set; }//Çocuk Sayısı
        public string RoomCount { get; set; }//Oda Sayısı
        public string SpecialRequest { get; set; }//Özel İstek
        public string Description { get; set; }//Açıklama
        public string Status { get; set; } //Durum
        public string City { get; set; } //Şehir
        public string Country { get; set; } //Ülke
    }
}

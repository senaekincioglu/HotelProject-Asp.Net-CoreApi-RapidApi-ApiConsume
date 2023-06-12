using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Room //Oda tablosu
    {
        public int RoomID { get; set; } //Oda ID
        public string RoomNumber { get; set; } // Oda Numarası
        public string RoomCoverImage { get; set; }//Oda Kapak Fotoğrafı
        public int Price { get; set; }//Oda Fiyatı
        public string Title { get; set; }//Oda başlığı
        public string BedCount { get; set; }//Oda yatak sayısı
        public string BathCount { get; set; }//banyo sayısı
        public string Wifi { get; set; } //Wifi
        public string Description { get; set; }//Oda açıklaması
    }
}

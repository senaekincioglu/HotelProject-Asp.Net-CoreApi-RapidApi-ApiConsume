using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Testimonial //Referans
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; } //Referans Adı
        public string Title { get; set; } //Referans Başlığı
        public string Description { get; set; } //Referans Yorumu yani Açıklaması
        public string Image { get; set; }//Referans yani bu kişinin görseli 
    }
}

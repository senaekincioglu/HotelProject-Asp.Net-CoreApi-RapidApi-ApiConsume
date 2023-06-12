using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Staff //Ekibimiz yani çalışanlar
    {
        public int StaffID { get; set; }
        public string Name { get; set; } //İsim
        public string Title { get; set; } //Başlık yani müdür, müdür yardımcısı şef gibi.
        public string SocialMedia1 { get; set; } //Sosyal Medya 1 
        public string SocialMedia2 { get; set; } //Sosyal Medya 2
        public string SocialMedia3 { get; set; }//Sosyal Medya 3
    }
}

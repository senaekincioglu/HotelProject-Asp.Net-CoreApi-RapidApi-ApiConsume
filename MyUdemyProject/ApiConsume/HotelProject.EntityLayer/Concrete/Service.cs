using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Service //Hizmetler
    {
        public int ServiceID { get; set; }
        public string ServiceIcon { get; set; } //İcon
        public string Title { get; set; } //Başlık
        public string Description { get; set; }//Açıklama
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HotelProject.WebUI.Models.Staff
{
    public class StaffViwModel
    {
        public int StaffID { get; set; }
        public string Name { get; set; } //İsim
        public string Title { get; set; } //Başlık yani müdür, müdür yardımcısı şef gibi
    }
}

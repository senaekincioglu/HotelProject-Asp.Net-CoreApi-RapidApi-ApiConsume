using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public string Country { get; set; }//Ülke
        public string Gender { get; set; }//Cinsiyet
        public string WorkDepartment { get; set; }
        //Her kullanıcının bir departmanı olduğundan dolayı kullanıcı yani AppUser tablosuna kullanıcı departman ıd eklenir.aşağıdaki gibi
        public int WorkLocationID { get; set; }

        //Ve Work location ıd türünde WorkLocation ıd si lazım.Aşağıdaki gibi
        public WorkLocation WorkLocation { get; set; }

    }
}

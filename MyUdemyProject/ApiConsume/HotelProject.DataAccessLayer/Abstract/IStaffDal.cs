using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IStaffDal : IGenericDal<Staff>
    {
        //tek bir değerin olduğu çıktıya ihityacımız var.
        int GetStaffCount();
        List<Staff> Last4Staff();  //son 4 çalışan
    }
}

using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IRoomDal : IGenericDal<Room>//Böylelikle Room entity si IGenericDal dan  (ekleme silme güncelleme listeleme gibi metotlardan) haberdar olmuş olur. 
    {
        int RoomCount();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T t); //Ekleme metodu 
        void TDelete(T t);//Silme metodu
        void TUpdate(T t);//Güncelleme metodu
        List<T> TGetList();//Listeleme metodu
        T TGetById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    //    Bu C# kodu, "HotelProject.DataAccessLayer.Abstract" isim alanında yer alan bir interface olan "IGenericDal"ı tanımlar. Bu interface, "T" tipinde bir generic parametre alır. "T" parametresi, bu interface'ı uygulayan sınıflar tarafından belirlenecek bir sınıf tipi olacaktır ve "class" olmalıdır.

    //"IGenericDal" interface'i, temel veri erişim işlevselliğini tanımlar. Bu işlevselliği sağlamak için, "Insert", "Delete", "Update", "GetList" ve "GetById" adlı beş yöntem bildirimi içerir.

    //"Insert" yöntemi, veri kaynağına yeni bir nesne eklemek için kullanılır.Bu yöntem, "T" tipinde bir nesne alır.
    //"Delete" yöntemi, veri kaynağından bir nesneyi silmek için kullanılır.Bu yöntem, "T" tipinde bir nesne alır.
    //"Update" yöntemi, veri kaynağındaki bir nesneyi güncellemek için kullanılır.Bu yöntem, "T" tipinde bir nesne alır.
    //"GetList" yöntemi, veri kaynağındaki tüm nesneleri bir liste olarak döndürmek için kullanılır. Bu yöntem, "T" tipinde bir liste döndürür.
    //"GetById" yöntemi, belirli bir kimlik değerine sahip nesneyi veri kaynağından almak için kullanılır.Bu yöntem, bir "int" türünde bir kimlik değeri alır ve "T" tipinde bir nesne döndürür.
    //Bu şekilde, "IGenericDal" interface'i, farklı sınıfların bu beş temel veri erişim işlevselliğini sağlamasını sağlar. Bu sayede, farklı veri kaynaklarından veri almak için farklı sınıflar kullanılabilir, ancak hepsi aynı temel veri erişim işlevselliğini sağlarlar.
    public interface IGenericDal<T> where T : class
    {
        //Crud işlemleri olmalı ve o işlemlere ait metotlar aşağıdaki gibidir.
        void Insert(T t); //Ekleme metodu 
        void Delete(T t);//Silme metodu
        void Update(T t);//Güncelleme metodu
        List<T> GetList();//Listeleme metodu
        T GetById(int id); //Id ye göre getirme metodu
    }
}

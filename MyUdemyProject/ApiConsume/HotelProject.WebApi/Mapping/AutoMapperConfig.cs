using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>(); //RoomAddDto nesnesinin özellikleri, Room sınıfının özelliklerine eşlenir.
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();//üstteki gibi bidaha tersine yazmana gerek kalmıyor.

            
           
        }
    }
}

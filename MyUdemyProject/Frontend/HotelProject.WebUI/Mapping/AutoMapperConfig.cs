using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile //Profile dan örnek alır bunu kendin yazarsın.
    {
        public AutoMapperConfig() //ctor yapılır 
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();//Service de ilk başta hata verir ctrl nokta yapılarak add referance entitylayer seçilir.
            CreateMap<UpdateServiceDto, Service>().ReverseMap();

            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();

            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();
            CreateMap<CreateBookingDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();

            CreateMap<ResultAppUserDto,AppUser>().ReverseMap(); 

        }
    }
}

using AutoMapper;

namespace HotelsManagementApp.Models
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDTO>();
        }
    }
}

using AutoMapper;
using Hotel.Common.DTOs;
using Hotel.Common.DTOs.Bases;
using Hotel.Common.Enumerators;
using Hotel.Repository.Entities;

namespace Hotel.Service.Helpers.Mappers
{
    public class ServiceMapperHelper: Profile
    {
        public ServiceMapperHelper()
        {
            CreateMap<RoomDto, RoomEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<RoomEntity, RoomDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (RoomStatus)src.Status));

            CreateMap<BaseRoomDto, RoomEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<RoomEntity, BaseRoomDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (RoomStatus)src.Status));

            CreateMap<FullBookingDto, BookingEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<BookingEntity, FullBookingDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (BookingStatus)src.Status));
        }
    }
}

using AutoMapper;
using cloudblues_api.Models.DTOs.Incoming;
using cloudblues_api.Models;
using cloudblues_api.Models.DTOs.Outgoing;

namespace cloudblues_api.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<DriverCreateDto, Driver>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1))
                .ForMember(
                    dest => dest.WorldChampionships,
                    opt => opt.MapFrom(src => src.WorldChampionships))
                .ForMember(
                    dest => dest.DateAdded,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(
                    dest => dest.DateUpdated,
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Driver, DriverDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(x => x.Id))
                .ForMember(
                    dest => dest.DriverNumber,
                    opt => opt.MapFrom(x => x.DriverNumber))
                .ForMember(
                    dest => dest.WorldChampionships,
                    opt => opt.MapFrom(x => x.WorldChampionships));
        }
    }
}

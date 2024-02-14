using AutoMapper;

using AppUpdatesManager.Application.DTOs;

using AppUpdatesManager.Application.Contracts;

namespace AppUpdatesManager.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IAppUpdateRequest, AppUpdateDto>()
                // .ForMember(dest => dest.FileContent, opt => opt.MapFrom(src => src.FileContent))
                // .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Checksum, opt => opt.MapFrom(src => src.Checksum))
                .ForMember(dest => dest.UpdateDescription, opt => opt.MapFrom(src => src.UpdateDescription));
        }

    }
}

using AutoMapper;
using USTrails.API.Models.Domain;
using USTrails.API.Models.DTO;

namespace USTrails.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto,Region>().ReverseMap();

            CreateMap<AddTrailRequestDto,Trail>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap();
            CreateMap<Difficulty,DifficultyDto>().ReverseMap();
            CreateMap<UpdateTrailRequestDto, Trail>().ReverseMap();
        }
    }
}

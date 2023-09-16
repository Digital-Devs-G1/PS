using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<ReportTracking, ReportTrackingResponse>();
        }
    }
}

using AutoMapper;
using WebApi.Domain.DTOs;
using WebApi.Domain.Model;

namespace WebApi.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.NameStudent, m => m.MapFrom(orig => orig.name));
        }
    }
}

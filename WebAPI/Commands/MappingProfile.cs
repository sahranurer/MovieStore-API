using AutoMapper;
using WebAPI.Application.DirectorOperations.Queries;
using WebAPI.Entities;

namespace WebAPI.Commands
{
    public class MappingProfile : Profile{
        public MappingProfile()
        {
            CreateMap<Director,DirectorViewModel>();

           
            
        }
    }
}
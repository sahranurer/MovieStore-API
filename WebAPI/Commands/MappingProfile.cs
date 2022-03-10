using AutoMapper;
using WebAPI.Application.ActorOperations.Commands;
using WebAPI.Application.ActorOperations.Queries;
using WebAPI.Application.DirectorOperations.Commands.CreateDirector;
using WebAPI.Application.DirectorOperations.Queries;
using WebAPI.Application.MovieOperations.Queries;
using WebAPI.Entities;

namespace WebAPI.Commands
{
    public class MappingProfile : Profile{
        public MappingProfile()
        {
            CreateMap<Director,DirectorViewModel>();
            CreateMap<Director,DirectorDetailViewModel>();
            CreateMap<CreateDirectorViewModel,Director>();


            CreateMap<Actor,ActorViewModel>()
             .ForMember(dets=>dets.Movie,opt=>opt.MapFrom(src=>src.Movie.Name));
            CreateMap<Actor,ActorDetailViewModel>()
             .ForMember(dest=>dest.Movie,opt=>opt.MapFrom(src=>src.Movie.Name));
            CreateMap<CreateActorViewModel,Actor>();


            CreateMap<Movie,MovieViewModel>()
             .ForMember(dest=>dest.Director,opt=>opt.MapFrom(src=>src.Director.Name));
            
           
            
        }
    }
}
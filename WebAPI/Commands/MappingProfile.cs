using AutoMapper;
using WebAPI.Application.ActorOperations.Commands;
using WebAPI.Application.ActorOperations.Queries;
using WebAPI.Application.CustomerOperations.Commands;
using WebAPI.Application.CustomerOperations.Queries;
using WebAPI.Application.DirectorOperations.Commands.CreateDirector;
using WebAPI.Application.DirectorOperations.Queries;
using WebAPI.Application.MovieOperations.Commands;
using WebAPI.Application.MovieOperations.Queries;
using WebAPI.Application.OrderOperations.Queries;
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
             .ForMember(dets=>dets.Movie,opt=>opt.MapFrom(src=>$"{src.Movie.Name}{" / Type :"} {src.Movie.MovieType}"));
            CreateMap<Actor,ActorDetailViewModel>()
             .ForMember(dest=>dest.Movie,opt=>opt.MapFrom(src=>$"{src.Movie.Name}{" / Type :"} {src.Movie.MovieType}"));
            CreateMap<CreateActorViewModel,Actor>();


            CreateMap<Movie,MovieViewModel>()
             .ForMember(dest=>dest.Director,opt=>opt.MapFrom(src=>$"{src.Director.Name}{src.Director.Surname}"));

            CreateMap<CreateMovieViewModel,Movie>();
            CreateMap<Movie,GetMovieDetailViewModel>()
            .ForMember(dest=>dest.Director,opt=>opt.MapFrom(src=>$"{src.Director.Name}{src.Director.Surname}")); 
            
           
            CreateMap<Customer,CustomerViewModel>()
              .ForMember(dest=>dest.Movie,opt=>opt.MapFrom(src=>$"{src.Movie.Name} {" / Type :"} {src.Movie.MovieType}"));
            CreateMap<CreateCustomerViewModel,Customer>();  

            CreateMap<Order,OrderViewModel>()
              .ForMember(dest=>dest.Customer,opt=>opt.MapFrom(src=>$"{src.Customer.Name} {src.Customer.Surname}"))
              .ForMember(dest=>dest.Movie,opt=>opt.MapFrom(src=>$"{src.Movie.Name} {" / Type :"} {src.Movie.MovieType}"));
        }
    }
}
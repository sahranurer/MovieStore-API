using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ActorViewModel> Handle(){
            var actors = _context.Actors.Include(x=>x.Movie).OrderBy(x=>x.ActorID).ToList<Actor>();
            List<ActorViewModel> avm = _mapper.Map<List<ActorViewModel>>(actors);
            return avm;

        }



    }

    public class ActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
      
        public  string Movie {get;set;}

     //    public List<ActedInMovieViewModel> Movies { get; set; }
     
    }
}
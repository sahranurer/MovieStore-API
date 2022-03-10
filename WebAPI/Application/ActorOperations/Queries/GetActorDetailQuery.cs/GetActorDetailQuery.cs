using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;

namespace WebAPI.Application.ActorOperations.Queries
{
    public class GetActorDetailQuery
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;
        public int ActorID { get; set; }

        public GetActorDetailQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
           var actor = _context.Actors.Include(x=>x.Movie).SingleOrDefault(x=>x.ActorID == ActorID);
           if (actor is null)
           {
               throw new InvalidOperationException("Böyle bir actor yok :)");
           }
           ActorDetailViewModel adv = _mapper.Map<ActorDetailViewModel>(actor);
           return adv;
        }
    }
    public class ActorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Movie { get; set; }
      

    }
}
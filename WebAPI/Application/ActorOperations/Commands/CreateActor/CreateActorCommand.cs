using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class CreateActorCommand
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorViewModel Model {get;set;}

        public CreateActorCommand(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var actor = _context.Actors.SingleOrDefault(x=>x.Name == Model.Name);
            if (actor is not null)
            {
                throw new InvalidOperationException("Böyle bir kullanıcı var");
            }

            actor = _mapper.Map<Actor>(Model);

            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

    }

    public class CreateActorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int MovieID { get; set; }
    }
}
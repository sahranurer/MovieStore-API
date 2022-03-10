using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class UpdateActorCommand{
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;
        public int ActorID { get; set; }
        public UpdateActorViewModel Model {get;set;}

        public UpdateActorCommand(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle(){
           var actor = _context.Actors.SingleOrDefault(x=>x.ActorID == ActorID);
           if (actor is  null)
           {
               throw new InvalidOperationException("Böyle bir kullanıcı bulunamadı.");
           }

           actor.Name =  string.IsNullOrEmpty(Model.Name.Trim()) != default ? Model.Name : actor.Name;
           actor.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) != default ? Model.Surname : actor.Surname;
           actor.MovieID = Model.MovieID != default ? Model.MovieID : actor.MovieID;

          
           _context.SaveChanges();
        }

    }

    public class UpdateActorViewModel{
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public int MovieID { get; set; }
    }
}
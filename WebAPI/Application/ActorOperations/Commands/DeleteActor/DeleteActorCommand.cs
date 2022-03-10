using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class DeleteActorCommand{
        private readonly IMovieDbContext _context;
        public int ActorID { get; set; }

        public DeleteActorCommand(IMovieDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var actor = _context.Actors.SingleOrDefault(x=>x.ActorID == ActorID);
            if (actor is null)
            {
                throw new InvalidOperationException("Böyle bir kullanıcı yok.");
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }

    }
}
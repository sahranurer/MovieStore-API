using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.DirectorOperations.Commands
{
    public class DeleteDirectorCommands{
        private readonly IMovieDbContext _context;

        public int DirectorID { get; set; }

        public DeleteDirectorCommands(IMovieDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var director = _context.Directors.SingleOrDefault(x=>x.DirectorID == DirectorID);
            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir director yok");
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
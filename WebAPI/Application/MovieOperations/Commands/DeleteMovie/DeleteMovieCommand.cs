using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class DeleteMovieCommand{
        private readonly IMovieDbContext _context;
        public int MovieID { get; set; }

        public DeleteMovieCommand(IMovieDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var movie = _context.Movies.SingleOrDefault(x=>x.MovieID == MovieID);
            if (movie is null)
            {
                throw new InvalidOperationException("Böyle bir film yok.");
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
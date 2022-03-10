using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class UpdateMovieCommand{
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;
        public int MovieID { get; set; }

        public UpdateMovieViewModel Model { get; set; }
        public UpdateMovieCommand(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
           var movie = _context.Movies.SingleOrDefault(x=>x.Name == Model.Name);
           if (movie is null)
           {
               throw new InvalidOperationException("Böyle bir kullanıcı yok");
           }

           movie.Name = string.IsNullOrEmpty(Model.Name.Trim()) != default ? Model.Name  : movie.Name;
           movie.MovieYear = string.IsNullOrEmpty(Model.MovieYear.Trim()) != default ? Model.MovieYear : movie.MovieYear;
           movie.MovieType = string.IsNullOrEmpty(Model.MovieType.Trim()) != default ? Model.MovieType : movie.MovieType;
           movie.MoviePrice = string.IsNullOrEmpty(Model.MoviePrice.Trim()) != default ? Model.MoviePrice : movie.MoviePrice;
           movie.DirectorID = Model.DirectorID != default ? Model.DirectorID : movie.DirectorID;

           _context.SaveChanges();
        }
        
    }

    public class UpdateMovieViewModel{
         public string Name { get; set; }
        public string MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }
        public int DirectorID { get; set; }
    }
}
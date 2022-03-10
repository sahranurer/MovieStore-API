using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.MovieOperations.Queries
{
    public class GetMovieDetailQuery{
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;
        public int MovieID { get; set; }

        public GetMovieDetailQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetMovieDetailViewModel Handle(){
            var movie = _context.Movies.SingleOrDefault(x=>x.MovieID == MovieID);
            if (movie is null)
            {
                throw new InvalidOperationException("Böyle bir film yok :)");
            }
            GetMovieDetailViewModel mvm = _mapper.Map<GetMovieDetailViewModel>(movie);
            return mvm;
        }





    }


    public class GetMovieDetailViewModel{
         public string Name { get; set; }
        public string MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }

        public string Director { get; set; }
      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.ActorOperations.Queries;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.MovieOperations.Queries
{
    public class GetMoviesQuery{
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<MovieViewModel> Handle(){
            var movies = _context.Movies.Include(x=>x.Director).Include(x=>x.Actors).ToList<Movie>();
            List<MovieViewModel> mvm = _mapper.Map<List<MovieViewModel>>(movies);
            return mvm;
        }

    }


    public class MovieViewModel{
          public string Name { get; set; }
        public string MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }

         public string Director { get; set; }

         public List<ActorViewModel> GetActors {get;set;}

       

    }
}
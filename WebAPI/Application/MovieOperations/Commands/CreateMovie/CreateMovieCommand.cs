using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class CreateMovieCommand
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieViewModel Model {get;set;}
        public CreateMovieCommand(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
           var movie = _context.Movies.SingleOrDefault(x=>x.Name == Model.Name);
           if (movie is not null)
           {
               throw new InvalidOperationException("Böyle bir film var");
           }
            movie = _mapper.Map<Movie>(Model);
           _context.Movies.Add(movie);
           _context.SaveChanges();

        }
    }
    public class CreateMovieViewModel
    {
        public string Name { get; set; }
        public string MovieYear { get; set; }
        public string MovieType { get; set; }
        public string MoviePrice { get; set; }

        public int DirectorID { get; set; }
    }
}
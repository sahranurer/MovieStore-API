using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommands
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

         public CreateDirectorViewModel Model { get; set; }

        public CreateDirectorCommands(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var directors = _context.Directors.SingleOrDefault(x=>x.Surname == Model.Surname );
            if (directors is not null)
            {
                throw new InvalidOperationException("Director mevcut lütfennn");
            }

            directors = _mapper.Map<Director>(Model);

            _context.Directors.Add(directors);
            _context.SaveChanges();
        }

    }

    public class CreateDirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TheMovieDirected { get; set; }
    }
}
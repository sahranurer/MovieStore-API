using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieDbContext _context;

        private readonly IMapper _mapper;
        public int DirectorID { get; set; }


        public GetDirectorDetailQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.DirectorID == DirectorID);
            if (director is null)
            {
                throw new InvalidOperationException("Director zaten yok :) ");
            }

            DirectorDetailViewModel dvm = _mapper.Map<DirectorDetailViewModel>(director);
            return dvm ;


        }
    }

    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TheMovieDirected { get; set; }
    }

}
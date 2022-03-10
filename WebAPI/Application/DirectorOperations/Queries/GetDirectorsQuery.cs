using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;

namespace WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly IMovieDbContext _context;

        private readonly IMapper _mapper;


        public GetDirectorsQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle(){
            var directorList = _context.Directors.ToList();
            List<DirectorViewModel> dvm = _mapper.Map<List<DirectorViewModel>>(directorList);
            return dvm;
        }


    }


    public class DirectorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        
         public string TheMovieDirected { get; set; }

         //public List<Mo
    }

}
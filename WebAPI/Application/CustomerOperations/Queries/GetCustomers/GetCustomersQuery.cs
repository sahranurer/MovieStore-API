using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.CustomerOperations.Queries
{
    public class GetCustomersQuery
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CustomerViewModel> Handle()
        {
            var customer = _context.Customers.Include(x => x.Movie).ToList<Customer>();
            List<CustomerViewModel> cvm = _mapper.Map<List<CustomerViewModel>>(customer);
            return cvm;
        }
    }

    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Movie { get; set; }
    }
}
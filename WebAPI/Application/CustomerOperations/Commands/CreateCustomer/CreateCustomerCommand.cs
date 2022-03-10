using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class CreateCustomerCommand
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerViewModel Model { get; set; }
        public CreateCustomerCommand(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Name == Model.Name);
            if (customer is not null)
            {
                throw new InvalidOperationException("Böyle bir customer var");
            }
            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
    public class CreateCustomerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int MovieID { get; set; }
    }
}
using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class DeleteCustomerCommand{
        private readonly IMovieDbContext _context;
        public int CustomerID { get; set; }

        public DeleteCustomerCommand(IMovieDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var customer = _context.Customers.SingleOrDefault(x=>x.CustomerID == CustomerID);
            if (customer is null)
            {
                throw new InvalidOperationException("Böyle bir kullanıcı yok");
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

    }
}
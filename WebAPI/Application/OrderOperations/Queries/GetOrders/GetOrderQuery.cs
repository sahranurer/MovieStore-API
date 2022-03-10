using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.OrderOperations.Queries
{
    public class GetOrderQuery{
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderQuery(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle(){
            var order = _context.Orders.Include(x=>x.Customer).Include(x=>x.Movie).OrderBy(x=>x.CustomerID).ToList<Order>();
            List<OrderViewModel> ovm = _mapper.Map<List<OrderViewModel>>(order);
            return ovm;
        }
    }
    public class OrderViewModel{

        public string Customer { get; set; }
       
        public string Movie { get; set; }

        public string MoviePrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
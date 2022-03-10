using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.OrderOperations.Queries;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Handle(){
            GetOrderQuery query = new GetOrderQuery(_context,_mapper);
            var result =query.Handle();
            return Ok(result);
        }

    }
}
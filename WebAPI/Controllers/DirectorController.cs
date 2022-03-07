using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DirectorOperations.Queries;
using WebAPI.DbOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors(){
            GetDirectorsQuery query = new GetDirectorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);

        }

      



    }
}
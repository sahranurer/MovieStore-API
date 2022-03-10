using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.MovieOperations.Queries;
using WebAPI.DbOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetMovies(){
            GetMoviesQuery query = new GetMoviesQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);

        }

    }
}
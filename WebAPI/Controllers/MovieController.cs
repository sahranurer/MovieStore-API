using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.MovieOperations.Commands;
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

        [HttpGet("{id}")]
        public IActionResult GetByMovie(int id){
            GetMovieDetailViewModel result ;
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context,_mapper);
            query.MovieID = id;
            result = query.Handle();
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieViewModel newMovie){
            CreateMovieCommand command = new CreateMovieCommand(_context,_mapper);
            command.Model = newMovie;
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id , [FromBody] UpdateMovieViewModel updateMovie){
            UpdateMovieCommand command = new UpdateMovieCommand(_context,_mapper);
            command.MovieID = id;
            command.Model = updateMovie;
            command.Handle();
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id){
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieID = id;
            command.Handle();
            return Ok();
        }

    }
}
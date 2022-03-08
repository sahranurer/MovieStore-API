using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.DirectorOperations.Commands;
using WebAPI.Application.DirectorOperations.Commands.CreateDirector;
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            DirectorDetailViewModel result;
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context,_mapper);
            query.DirectorID = id;
            result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorViewModel  newDirector){
            CreateDirectorCommands command = new CreateDirectorCommands(_context,_mapper);
            command.Model = newDirector;
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id,[FromBody] UpdateDirectorViewModel updateDirector){
            UpdateDirectorCommands command = new UpdateDirectorCommands(_context);
            command.DirectorID = id;
            command.Model = updateDirector;
            command.Handle();
            return Ok();
        }
      
      [HttpDelete("{id}")]
      public IActionResult DeleteDirector(int id){
          DeleteDirectorCommands command = new DeleteDirectorCommands(_context);
          command.DirectorID = id;
          command.Handle();
          return Ok();
      }



    }
}
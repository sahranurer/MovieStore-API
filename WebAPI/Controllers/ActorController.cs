using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.ActorOperations.Commands;
using WebAPI.Application.ActorOperations.Queries;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
     
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieDbContext _context ;
        private readonly IMapper _mapper;


        public ActorController(IMovieDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors(){
           GetActorsQuery query = new GetActorsQuery(_context,_mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByActor(int id){
            ActorDetailViewModel result ;
            GetActorDetailQuery query = new GetActorDetailQuery(_context,_mapper);
            query.ActorID = id;
            result = query.Handle();
            return Ok(result);


        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorViewModel newActor){
             CreateActorCommand command = new CreateActorCommand(_context,_mapper);
             command.Model = newActor;
             command.Handle();
             return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id,[FromBody] UpdateActorViewModel updateActor){
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.ActorID=id;
            command.Model = updateActor;
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id){
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorID = id;
            command.Handle();
            return Ok();
        }



    }
}
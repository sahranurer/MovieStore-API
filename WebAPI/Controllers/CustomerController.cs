using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Application.CustomerOperations.Commands;
using WebAPI.Application.CustomerOperations.Queries;
using WebAPI.DbOperations;
using WebAPI.TokenOperations.Models;

namespace WebAPI.Controllers
{
     
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

          readonly IConfiguration _configuration;

        public CustomerController(IMovieDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetCustomers(){
            GetCustomersQuery query = new GetCustomersQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer){
            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            command.Model = newCustomer;
            command.Handle();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id){
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerID = id;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody]CreateTokenModel login ){
            CreateTokenCommand command = new CreateTokenCommand(_context,_mapper,_configuration);
            command.Model = login;
            var token = command.Handle();
            return token;
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token ){
            RefreshTokenCommand command = new RefreshTokenCommand(_context,_configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }



    }
}
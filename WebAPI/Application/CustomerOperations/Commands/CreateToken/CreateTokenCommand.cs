using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebAPI.DbOperations;
using WebAPI.TokenOperations;
using WebAPI.TokenOperations.Models;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class CreateTokenCommand
    {
        private readonly IMovieDbContext _context;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public CreateTokenModel Model {get;set;}

        public CreateTokenCommand(IMovieDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x=>x.Email == Model.Email && x.Password == Model.Password);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
               return token;
            }
            else
               throw new InvalidOperationException("Kullanıcı adı veya şifre yanlış");
        }

    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
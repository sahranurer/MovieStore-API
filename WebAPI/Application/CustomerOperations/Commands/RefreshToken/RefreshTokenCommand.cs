using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using WebAPI.DbOperations;
using WebAPI.TokenOperations;
using WebAPI.TokenOperations.Models;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class RefreshTokenCommand{
        private readonly IMovieDbContext _context;
        readonly IConfiguration _configuration;
       public string RefreshToken{get;set;}

        public RefreshTokenCommand(IMovieDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

          public Token Handle(){
           var user = _context.Customers.FirstOrDefault(x=>x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
           if(user is not null){
               //token yarat
               TokenHandler handler = new TokenHandler(_configuration);
               Token token = handler.CreateAccessToken(user);
               user.RefreshToken = token.RefreshToken;
               user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
               _context.SaveChanges();
               return token;
           }
           else 
             throw new InvalidOperationException("Validate bir refresh token bulunamadı");
       }
    }
    }

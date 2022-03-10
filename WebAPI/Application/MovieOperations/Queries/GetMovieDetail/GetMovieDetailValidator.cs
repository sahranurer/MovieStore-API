using FluentValidation;

namespace WebAPI.Application.MovieOperations.Queries
{
    public class GetMovieDetailValidator :  AbstractValidator<GetMovieDetailQuery>{
           GetMovieDetailValidator()
          {
                RuleFor(command=>command.MovieID).GreaterThan(0);  
          }
    }
}
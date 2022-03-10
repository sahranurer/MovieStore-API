using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>{
        public UpdateMovieCommandValidator()
        {
            RuleFor(command=>command.MovieID).GreaterThan(0);
            RuleFor(command=>command.Model.MovieType).NotEmpty();
            RuleFor(command=>command.Model.MovieYear).NotEmpty();
        }
    }
}
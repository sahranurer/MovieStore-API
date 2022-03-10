using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command=>command.MovieID).NotEmpty();
        }
    }
}
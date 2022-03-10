using System;
using FluentValidation;

namespace WebAPI.Application.MovieOperations.Commands
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>{
        public CreateMovieCommandValidator()
        {
            RuleFor(command=>command.Model.DirectorID).GreaterThan(0);
            RuleFor(command=>command.Model.MoviePrice).NotEmpty();
           // RuleFor(command=>command.Model.MovieYear).LessThan(p => DateTime.Now);
            RuleFor(command=>command.Model.MovieType).NotEmpty();

        }
    }
}
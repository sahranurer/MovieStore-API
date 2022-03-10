using FluentValidation;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>{
      public UpdateActorCommandValidator()
      {
           RuleFor(command=>command.Model.MovieID).NotEmpty();
            RuleFor(command=>command.Model.Name).NotEmpty();
            RuleFor(command=>command.Model.Surname).NotEmpty();
      }
    }
}
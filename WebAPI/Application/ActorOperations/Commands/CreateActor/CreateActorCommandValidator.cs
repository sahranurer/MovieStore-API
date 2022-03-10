using FluentValidation;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>{
        public CreateActorCommandValidator()
        {
            RuleFor(command=>command.Model.MovieID).NotEmpty();
            RuleFor(command=>command.Model.Name).NotEmpty();
            RuleFor(command=>command.Model.Surname).NotEmpty();

        }
    }
}
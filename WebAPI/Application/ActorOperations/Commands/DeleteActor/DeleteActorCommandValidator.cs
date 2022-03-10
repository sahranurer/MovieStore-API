using FluentValidation;

namespace WebAPI.Application.ActorOperations.Commands
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>{
        public DeleteActorCommandValidator()
        {
            RuleFor(command=>command.ActorID).NotEmpty();
        }
    }
}
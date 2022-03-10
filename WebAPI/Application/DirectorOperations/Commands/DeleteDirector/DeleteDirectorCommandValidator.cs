using FluentValidation;

namespace WebAPI.Application.DirectorOperations.Commands
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommands>{
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command=>command.DirectorID).GreaterThan(0);
        }
    }
}
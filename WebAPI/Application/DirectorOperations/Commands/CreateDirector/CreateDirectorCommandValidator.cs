using FluentValidation;
using WebAPI.Application.DirectorOperations.Commands.CreateDirector;

namespace WebAPI.Application.DirectorOperations.Commands
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommands>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
        }
    }
}
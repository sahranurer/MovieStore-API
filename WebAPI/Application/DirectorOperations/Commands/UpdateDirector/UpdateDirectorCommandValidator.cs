using FluentValidation;

namespace WebAPI.Application.DirectorOperations.Commands
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommands>{
        public UpdateDirectorCommandValidator()
        {
            
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
        }
    }
}
using FluentValidation;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>{
        public CreateCustomerCommandValidator()
        {
            RuleFor(command=>command.Model.Email).EmailAddress().WithMessage("E-mail Formatında giriniz.");
            RuleFor(command=>command.Model.Password).Length(1,10).WithMessage("Şifre 1-10 uzunluğunu geçmemelidir.");
            
        }
    }
}
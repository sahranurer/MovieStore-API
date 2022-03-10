using FluentValidation;

namespace WebAPI.Application.CustomerOperations.Commands
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>{
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command=>command.CustomerID).GreaterThan(0);
        }
    }
}
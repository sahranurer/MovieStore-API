using System;
using FluentValidation;

namespace WebAPI.Application.DirectorOperations.Queries
{
    public class GetDirectorCommandValidator : AbstractValidator<GetDirectorDetailQuery>{
        public GetDirectorCommandValidator()
        {
            RuleFor(command=>command.DirectorID).GreaterThan(0);
            

        }
    }
}
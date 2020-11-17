using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            base.RuleFor(customer => customer.Email).NotNull().EmailAddress();
        }
    }
}

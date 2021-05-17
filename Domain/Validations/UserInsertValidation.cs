using Domain.Repositories;
using Domain.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class UserInsertValidation : AbstractValidator<UserInsertViewModel>
    {
        public UserInsertValidation(IUserRepository userRepository)
        {
            RuleFor(e => e.Email).EmailAddress()
            .WithMessage("Email inválido");
        }
    }
}

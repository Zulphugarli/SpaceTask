using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class AddUserValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserValidator()
        {
            RuleFor(m => m.Email).NotEmpty();
            RuleFor(m => m.MobilePhone).NotEmpty();
            RuleFor(m => m.Username).NotEmpty();
        }
    }
    
}


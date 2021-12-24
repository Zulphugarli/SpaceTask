using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdValidator()
        {
            RuleFor(m => m.UserId).NotEmpty();
        }
    }
}

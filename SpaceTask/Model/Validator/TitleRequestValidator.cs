using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
   
    public class TitleRequestValidator : AbstractValidator<TitleRequest>
    {
        public TitleRequestValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

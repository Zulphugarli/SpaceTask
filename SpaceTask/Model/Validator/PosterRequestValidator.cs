using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class PosterRequestValidator : AbstractValidator<PosterRequest>
    {
        public PosterRequestValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

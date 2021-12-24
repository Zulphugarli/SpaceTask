using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class WikipediaRequestValidator : AbstractValidator<WikipediaRequest>
    {
        public WikipediaRequestValidator()
        {
            RuleFor(m => m.Id).NotEmpty();
        }
    }
}

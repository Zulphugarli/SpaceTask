using FluentValidation;
using FluentValidation.Validators;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class AddWatchlistValidator : AbstractValidator<AddWatchlistRequest>
    {
        public AddWatchlistValidator()
        {
            RuleFor(m => m.MovieId).NotNull();
            RuleFor(m => m.UserId).NotNull();
            RuleFor(x => x.IsWatched).SetValidator(new BoolValidator());
        }
    }   
}

using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class UpdateMovieWatchedValidator : AbstractValidator<UpdateMovieWatchedRequest>
    {
        public UpdateMovieWatchedValidator()
        {
            RuleFor(m => m.MovieId).NotEmpty();
            RuleFor(m => m.UserId).NotEmpty();
            RuleFor(x => x.IsWatched).SetValidator(new BoolValidator());
        }
    }
}

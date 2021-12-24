using FluentValidation;
using SpaceTask.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class AddMovieValidator : AbstractValidator<AddMovieRequest>
    {
        public AddMovieValidator()
        {
            RuleFor(m => m.MovieName).NotEmpty();
        }
    }
}

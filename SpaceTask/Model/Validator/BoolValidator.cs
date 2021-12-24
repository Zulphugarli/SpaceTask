using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTask.Model.Validator
{
    public class BoolValidator : PropertyValidator
    {
        public BoolValidator()
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            bool boolType = (bool)context.PropertyValue;
            if (boolType == false || boolType == true)
                return true;

            return false;
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using Football.Crosscutting.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Football.Crosscutting.Validators
{
    public class CompetitionValidator: AbstractValidator<Competition>
    {
        public CompetitionValidator()
        {
            RuleFor(competition => competition.RoundList).NotNull();
            RuleFor(competition => competition.RoundList).NotEmpty();
            RuleFor(competition => competition.Name).NotEmpty();
            //RuleFor(competition => competition).Custom((x, context) => {
            //    if (x.Name == "Invalid")
            //    {
            //       var validationFailure = new ValidationFailure(
            //            "Name", "The name cannot be invalid.");
            //        context.AddFailure(validationFailure);
            //    }
                
            //});
            RuleFor(competition => competition.Season).NotEmpty();
        }

        private ValidationFailure ThisOne(string name)
        {
            if (name == "Invalid")
            {
                return new ValidationFailure(
                    "name", "You can not delete definition that has already been distributed.");
            }

            return null;
        }
    }
}

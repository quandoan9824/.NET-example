using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        private readonly ILogger<FormService> _logger;
        public ApplicantValidator(ILogger<FormService> logger)
        {
            FormService _sv = new FormService(logger);
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.FamilyName).MinimumLength(5);
            RuleFor(x => x.Address).MinimumLength(10);
            RuleFor(x => x.CountryOfOrigin).MinimumLength(10).MustAsync(async (country, cancellation) => {
                bool exists = await _sv.ValidateCountry(country);
                return exists;
            }).WithMessage("Cannot find the country");
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(20, 60);
            RuleFor(x => x.Hired).NotNull();

        }
    }
}

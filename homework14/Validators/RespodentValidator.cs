using FluentValidation;
using homework14.Models;
using System;

namespace homework14.Validators
{
    public class RespodentValidator : AbstractValidator<Respodent>
    {
        public RespodentValidator()
        {
            RuleFor(x => x.CreateDate)
                .NotNull().WithMessage("date is required field")
                .Must(isDateValid).WithMessage("invalid Date detected");
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("Name is required field")
                .NotEmpty().WithMessage("Name cant be empty")
                .MinimumLength(1).WithMessage("name character length must be in range 1 - 50")
                .MaximumLength(50).WithMessage("name character length must be in range 1 - 50");
            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Last Name is required field")
                .NotEmpty().WithMessage("Last Name cant be empty")
                .MinimumLength(1).WithMessage("Last name character length must be in range 1 - 50")
                .MaximumLength(50).WithMessage("Last name character length must be in range 1 - 50");
            RuleFor(x => x.JobPosition)
                .NotNull().WithMessage("Job Position is required field")
                .NotEmpty().WithMessage("Job Position cant be empty")
                .MinimumLength(1).WithMessage("Job Position character length must be in range 1 - 50")
                .MaximumLength(50).WithMessage("Job Position character length must be in range 1 - 50");
            RuleFor(x => x.Salary)
                .NotNull().WithMessage("Salary is required field")
                .ExclusiveBetween(0, 10000).WithMessage("out of expected salary range");
            RuleFor(x => x.WorkExperience)
                .NotNull().WithMessage("Work experience is required field")
                .NotEmpty().WithMessage("Work experience cant be empty");
            RuleFor(x => x.PersonAddress)
                .NotNull().WithMessage("Address is required field");
            RuleFor(x => x.PersonAddress.Country)
                .NotNull().WithMessage("Country is missing from address field")
                .NotEmpty().WithMessage("Country cant be empty");
            RuleFor(x => x.PersonAddress.City)
                .NotNull().WithMessage("City is missing from address field")
                .NotEmpty().WithMessage("City cant be empty");
            RuleFor(x => x.PersonAddress.HomeNumber)
                .NotNull().WithMessage("Home Number is missing from address field")
                .NotEmpty().WithMessage("Home Number cant be empty");

        }

        private bool isDateValid(string dateString)
        {
            bool result = false;
            DateTime respodentTime;
            DateTime dateNow = DateTime.Now;

            if (DateTime.TryParse(dateString, out respodentTime) && dateNow > respodentTime)
                result = true;

            return result;
        }
    }
}

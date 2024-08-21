using System;
using Domain.DTOs;
using FluentValidation;

namespace Application.Activities
{
	public class AddActivityValidator : AbstractValidator<ActivityAddRequest>
	{
		public AddActivityValidator()
		{
			RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();

        }
	}
}


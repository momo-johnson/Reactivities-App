using System;
using Domain.DTOs;
using FluentValidation;
using MediatR;

namespace Application.Activities.Commands
{
	public class AddActivityCommand : IRequest
	{
		public ActivityAddRequest? ActivityRequest { get; set; }
	}

	public class AddActivityCommandValidator: AbstractValidator<AddActivityCommand>
	{
		public AddActivityCommandValidator()
		{
			RuleFor(x => x.ActivityRequest).SetValidator(new AddActivityValidator());
		}
	}
}


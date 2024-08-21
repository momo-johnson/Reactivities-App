using System;
using Application.Activities.Validators;
using Domain.DTOs;
using FluentValidation;
using MediatR;

namespace Application.Activities.Commands
{
	public class UpdateActivityCommand : IRequest
	{
		public ActivityUpdateRequest? ActivityUpdateRequest { get; set; }
	}

    public class UpdateActivityCommandValidator : AbstractValidator<UpdateActivityCommand>
    {
        public UpdateActivityCommandValidator()
        {
            RuleFor(x => x.ActivityUpdateRequest).SetValidator(new UpdateActivityValidator());
        }
    }
}


using System;
using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Activities.Queries
{
	public class GetActivityQuery : IRequest<ActivityResponse>
	{
		public Guid ID { get; set; }
	}
}


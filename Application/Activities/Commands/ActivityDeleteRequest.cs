using System;
using MediatR;

namespace Application.Activities.Commands
{
	public class ActivityDeleteRequest : IRequest
	{
		public Guid ID { get; set; }
	}
}


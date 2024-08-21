using System;
using System.Net;

namespace Domain.DTOs
{
	public record CQRSResponse
	{
		public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
		public string ErrorMessage { get; init; }

	}
}


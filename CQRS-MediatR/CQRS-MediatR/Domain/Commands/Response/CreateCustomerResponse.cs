using System;

namespace CQRS_MediatR.Domain.Commands.Response
{
	public class CreateCustomerResponse
	{
		public Guid Guid { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime Date { get; set; }
	}
}
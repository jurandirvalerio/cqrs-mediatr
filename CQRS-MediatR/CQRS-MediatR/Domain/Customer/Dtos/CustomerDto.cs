using System;

namespace CQRS_MediatR.Domain.Customer.Dtos
{
	public class CustomerDto
	{
		public Guid Guid { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
	}
}
using System;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Commands
{
	public class DeleteCustomerCommand : IRequest<string>
	{
		public Guid Guid { get; set; }
	}
}

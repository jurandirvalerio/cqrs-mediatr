using System;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Commands
{
	namespace MediatorPatternExample.Domain.Customer.Command
	{
		public class UpdateCustomerCommand : IRequest<string>
		{
			public Guid Guid { get; set; }
			public string Name { get; set; }
			public string Email { get; set; }
		}
	}
}
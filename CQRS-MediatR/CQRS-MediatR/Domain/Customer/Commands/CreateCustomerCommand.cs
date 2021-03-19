using MediatR;

namespace CQRS_MediatR.Domain.Customer.Commands
{
	public class CreateCustomerCommand : IRequest<string>
	{
		public string Name { get; set; }
		public string Email { get; set; }
    }
}
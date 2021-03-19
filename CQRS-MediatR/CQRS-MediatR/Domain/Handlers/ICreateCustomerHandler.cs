using CQRS_MediatR.Domain.Commands.Requests;
using CQRS_MediatR.Domain.Commands.Response;

namespace CQRS_MediatR.Domain.Handlers
{
	public interface ICreateCustomerHandler
	{
		CreateCustomerResponse Handler(CreateCustomerRequest createCustomerRequest);
	}
}
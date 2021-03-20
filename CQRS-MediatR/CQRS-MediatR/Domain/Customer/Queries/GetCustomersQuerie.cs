using System.Collections.Generic;
using CQRS_MediatR.Domain.Customer.Dtos;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Queries
{
	public class GetCustomersQuerie : IRequest<IEnumerable<CustomerDto>>
	{
	}
}
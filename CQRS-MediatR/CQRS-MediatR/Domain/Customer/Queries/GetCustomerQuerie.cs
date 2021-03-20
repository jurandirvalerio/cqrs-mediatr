using System;
using CQRS_MediatR.Domain.Customer.Dtos;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Queries
{
	public class GetCustomerQuerie : IRequest<CustomerDto>
	{
		public GetCustomerQuerie(Guid guid)
		{
			Guid = guid;
		}

		public Guid Guid { get; set; }
	}
}
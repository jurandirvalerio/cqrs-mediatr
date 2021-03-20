using System.Collections.Generic;
using CQRS_MediatR.Domain.Customer.Dtos;
using CQRS_MediatR.Domain.Customer.Entity;

namespace CQRS_MediatR.Domain.Infrastructure.Mappers
{
	public interface ICustomerMapper
	{
		CustomerDto Map(CustomerEntity customerEntity);
		IEnumerable<CustomerDto> Map(IEnumerable<CustomerEntity> customerEntitySet);
	}
}
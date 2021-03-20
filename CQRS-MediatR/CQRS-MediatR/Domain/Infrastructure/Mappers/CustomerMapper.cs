using System.Collections.Generic;
using System.Linq;
using CQRS_MediatR.Domain.Customer.Dtos;
using CQRS_MediatR.Domain.Customer.Entity;

namespace CQRS_MediatR.Domain.Infrastructure.Mappers
{
	public class CustomerMapper : ICustomerMapper
	{
		public CustomerDto Map(CustomerEntity customerEntity)
		{
			return new CustomerDto
			{
				Email = customerEntity.Email,
				Name = customerEntity.Email,
				Guid = customerEntity.Guid
			};
		}

		public IEnumerable<CustomerDto> Map(IEnumerable<CustomerEntity> customerEntitySet) => customerEntitySet.Select(Map);
	}
}
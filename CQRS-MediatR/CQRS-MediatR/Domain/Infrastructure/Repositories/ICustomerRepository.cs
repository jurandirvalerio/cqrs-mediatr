using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Customer.Entity;

namespace CQRS_MediatR.Domain.Infrastructure.Repositories
{
	public interface ICustomerRepository
	{
		Task Save(CustomerEntity customer);
		Task Update(Guid guid, CustomerEntity customer);
		Task Delete(Guid guid);
		Task<CustomerEntity> GetById(Guid guid);
		Task<IEnumerable<CustomerEntity>> GetAll();
	}
}
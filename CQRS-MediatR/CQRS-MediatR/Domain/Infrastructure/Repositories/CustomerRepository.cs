using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Customer.Entity;

namespace CQRS_MediatR.Domain.Infrastructure.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		public List<CustomerEntity> Customers { get; }

		public CustomerRepository()
		{
			Customers = new List<CustomerEntity>();
		}

		public async Task Save(CustomerEntity customer)
		{
			await Task.Run(() => Customers.Add(customer));
		}

		public async Task<IEnumerable<CustomerEntity>> GetAll()
		{
			return await Task.FromResult(Customers);
		}

		public async Task Update(Guid guid, CustomerEntity customer)
		{
			var index = Customers.FindIndex(m => m.Guid == guid);
			if (index >= 0) await Task.Run(() => Customers[index] = customer);
		}

		public async Task Delete(Guid guid)
		{
			await Task.Run(() => Customers.RemoveAt(Customers.FindIndex(m => m.Guid == guid)));
		}

		public async Task<CustomerEntity> GetById(Guid guid)
		{
			var result = Customers.FirstOrDefault(p => p.Guid == guid);
			return await Task.FromResult(result);
		}
	}
}
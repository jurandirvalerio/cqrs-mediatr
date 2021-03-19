using System;

namespace CQRS_MediatR.Domain.Customer.Entity
{
	public class CustomerEntity
	{
		public CustomerEntity(Guid guid, string name, string email)
		{
			Guid = guid;
			Email = email;
			Name = name;
		}

		public Guid Guid { get; }
		public string Email { get; }
		public string Name { get; }
    }
}
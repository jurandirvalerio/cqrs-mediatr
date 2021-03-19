using System;
using CQRS_MediatR.Domain.Commands.Requests;
using CQRS_MediatR.Domain.Commands.Response;

namespace CQRS_MediatR.Domain.Handlers
{
	public class CreateCustomerHandler : ICreateCustomerHandler
	{
		public CreateCustomerResponse Handler(CreateCustomerRequest createCustomerRequest)
		{
			// verifica se o cliente está cadastrado 
			// valida dados
			//insere o cliente
			//envia email

			return new CreateCustomerResponse
			{
				Date = DateTime.Now,
				Email = "email@email.com",
				Guid = Guid.NewGuid(),
				Name = "Random name"
			};
		}
	}
}
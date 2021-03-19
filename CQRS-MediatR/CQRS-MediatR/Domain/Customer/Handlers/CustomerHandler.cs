using CQRS_MediatR.Domain.Customer.Commands;
using CQRS_MediatR.Domain.Customer.Commands.MediatorPatternExample.Domain.Customer.Command;
using CQRS_MediatR.Domain.Customer.Entity;
using CQRS_MediatR.Domain.Infrastructure.Repositories;
using CQRS_MediatR.Domain.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Domain.Customer.Handlers
{
    public class CustomerHandler :
       IRequestHandler<CreateCustomerCommand, string>,
       IRequestHandler<UpdateCustomerCommand, string>,
       IRequestHandler<DeleteCustomerCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(Guid.NewGuid() , createCustomerCommand.Name, createCustomerCommand.Email);
            await _customerRepository.Save(customer);

            await _mediator.Publish(new CustomerActionNotification
            {
                Name = createCustomerCommand.Name,
                Email = createCustomerCommand.Email,
                Action = ActionNotification.Created
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(updateCustomerCommand.Guid, updateCustomerCommand.Name, updateCustomerCommand.Email);
            await _customerRepository.Update(updateCustomerCommand.Guid, customer);

            await _mediator.Publish(new CustomerActionNotification
            {
                Name = updateCustomerCommand.Name,
                Email = updateCustomerCommand.Email,
                Action = ActionNotification.Updated
            }, cancellationToken);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(DeleteCustomerCommand deleteCustomerCommand, CancellationToken cancellationToken)
        {
            var client = await _customerRepository.GetById(deleteCustomerCommand.Guid);
            await _customerRepository.Delete(deleteCustomerCommand.Guid);

            await _mediator.Publish(new CustomerActionNotification
            {
                Name = client.Name,
                Email = client.Email,
                Action = ActionNotification.Deleted
            }, cancellationToken);

            return await Task.FromResult("Cliente excluido com sucesso");
        }
    }
}
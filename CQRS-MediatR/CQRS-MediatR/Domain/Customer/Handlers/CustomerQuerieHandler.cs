using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Customer.Dtos;
using CQRS_MediatR.Domain.Customer.Queries;
using CQRS_MediatR.Domain.Infrastructure.Mappers;
using CQRS_MediatR.Domain.Infrastructure.Repositories;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Handlers
{
	public class CustomerQuerieHandler :
		IRequestHandler<GetCustomerQuerie, CustomerDto>,
		IRequestHandler<GetCustomersQuerie, IEnumerable<CustomerDto>>
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly ICustomerMapper _customerMapper;

		public CustomerQuerieHandler(ICustomerRepository customerRepository, ICustomerMapper customerMapper)
		{
			_customerRepository = customerRepository;
			_customerMapper = customerMapper;
		}

		public async Task<CustomerDto> Handle(GetCustomerQuerie request, CancellationToken cancellationToken)
		{
			var result = _customerMapper.Map(await _customerRepository.GetByGuid(request.Guid));
			return await Task.FromResult(result);
		}

		public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuerie request, CancellationToken cancellationToken)
		{
			var result = _customerMapper.Map(await _customerRepository.GetAll());
			return await Task.FromResult(result);
		}
	}
}
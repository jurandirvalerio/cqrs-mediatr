using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Customer.Commands;
using CQRS_MediatR.Domain.Customer.Commands.MediatorPatternExample.Domain.Customer.Command;
using CQRS_MediatR.Domain.Customer.Dtos;
using CQRS_MediatR.Domain.Customer.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CustomerController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Post(CreateCustomerCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Put(UpdateCustomerCommand command)
		{
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("{guid}")]
		public async Task<IActionResult> Delete(Guid guid)
		{
			var dto = new DeleteCustomerCommand { Guid = guid };
			var result = await _mediator.Send(dto);
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> GetAllAsync()
		{
			var customerDtoSet = await _mediator.Send(new GetCustomersQuerie());
			if (customerDtoSet == null) return NotFound();
			return Ok(customerDtoSet);
		}

		[HttpGet("{guid}")]
		[ProducesResponseType(typeof(CustomerDto), 200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(404)]
		public async Task<ActionResult<CustomerDto>> GetAsync(Guid guid)
		{
			var customerDto = await _mediator.Send(new GetCustomerQuerie(guid));
			return Return(customerDto);
		}

		private ActionResult<CustomerDto> Return(CustomerDto customerDto)
		{
			if (customerDto == null) return NotFound();
			return Ok(customerDto);
		}
	}
}
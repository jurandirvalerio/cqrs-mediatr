using System;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Customer.Commands;
using CQRS_MediatR.Domain.Customer.Commands.MediatorPatternExample.Domain.Customer.Command;
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
		public async Task<IActionResult> GetAll()
		{
			throw new NotImplementedException("Implementar querie");
		}

		[HttpGet("{guid}")]
		public async Task<IActionResult> Get(Guid guid)
		{
			throw new NotImplementedException("Implementar querie");
		}
	}
}
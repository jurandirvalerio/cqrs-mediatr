using CQRS_MediatR.Domain.Commands.Requests;
using CQRS_MediatR.Domain.Commands.Response;
using CQRS_MediatR.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers
{
	[ApiController]
	[Route("v1/customers")]
	public class CustomerController : ControllerBase
	{
		private readonly ICreateCustomerHandler _createCustomerHandler;

		public CustomerController(ICreateCustomerHandler createCustomerHandler)
		{
			_createCustomerHandler = createCustomerHandler;
		}

		[HttpGet]
		public IActionResult Get() => new OkResult();

		[HttpPost]
		public CreateCustomerResponse Create(
			[FromBody]CreateCustomerRequest createCustomerRequest)
		{
			return _createCustomerHandler.Handler(createCustomerRequest);
		}
	}
}

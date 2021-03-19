namespace CQRS_MediatR.Domain.Commands.Requests
{
	public class CreateCustomerRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
	}
}

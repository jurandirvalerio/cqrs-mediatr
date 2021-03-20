using CQRS_MediatR.Domain.Infrastructure.Mappers;
using CQRS_MediatR.Domain.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS_MediatR.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddSingleton<ICustomerRepository, CustomerRepository>();
			services.AddSingleton<ICustomerMapper, CustomerMapper>();
		}
    }
}
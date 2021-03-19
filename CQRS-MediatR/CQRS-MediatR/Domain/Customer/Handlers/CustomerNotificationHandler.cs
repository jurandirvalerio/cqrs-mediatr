using System;
using System.Threading;
using System.Threading.Tasks;
using CQRS_MediatR.Domain.Notifications;
using MediatR;

namespace CQRS_MediatR.Domain.Customer.Handlers
{
	public class CustomerNotificationHandler : INotificationHandler<CustomerActionNotification>
	{
		public Task Handle(CustomerActionNotification customerActionNotification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine($"O cliente {customerActionNotification.Name} foi {StatusDictionary(customerActionNotification.Action)} com sucesso");
			});
		}

		private string StatusDictionary(ActionNotification notificationAction)
		{
			switch (notificationAction)
			{
				case ActionNotification.Created: return "criado";
				case ActionNotification.Updated: return "atualizado";
				case ActionNotification.Deleted: return "excluído";
				default:
					throw new ArgumentOutOfRangeException(nameof(notificationAction), notificationAction, null);
			}
		}
	}
}

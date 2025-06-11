using CompanyEmployees.Application.Company.Notifications;
using LoggingService;
using MediatR;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class EmailCompanyHandler : INotificationHandler<CompanyDeletedNotification>
    {
        private readonly ILoggerManager _logger;

        public EmailCompanyHandler(ILoggerManager logger)
        {
            this._logger = logger;
        }

        public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Delete action for the company with id: {notification.id} has occurred");

            await Task.CompletedTask;
        }
    }
}

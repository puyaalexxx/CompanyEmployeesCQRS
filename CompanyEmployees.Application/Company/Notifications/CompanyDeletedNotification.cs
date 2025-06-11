using MediatR;

namespace CompanyEmployees.Application.Company.Notifications
{
    public sealed record class CompanyDeletedNotification(Guid id, bool TrackChanges) : INotification;
}

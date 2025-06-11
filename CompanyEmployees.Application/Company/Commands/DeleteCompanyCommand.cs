using MediatR;

namespace CompanyEmployees.Application.Company.Commands
{
    public sealed record class DeleteCompanyCommand(Guid id, bool TrackChanges) : IRequest;
}

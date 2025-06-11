using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Commands
{
    public sealed record class UpdateCompanyCommand(Guid Id, CompanyForUpdateDto Company, bool TrackChanges) : IRequest;
}

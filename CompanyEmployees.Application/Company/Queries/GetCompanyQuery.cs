using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Queries
{
    public sealed record class GetCompanyQuery(Guid Id, bool TrackChanges) : IRequest<CompanyDto>;
}

using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Commands
{
    public sealed record class CreateCompanyCommand(CompanyForCreationDto Company) : IRequest<CompanyDto>;
}

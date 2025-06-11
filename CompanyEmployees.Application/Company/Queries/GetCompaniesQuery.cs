using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Application.Company.Queries
{
    public sealed record class GetCompaniesQuery(bool trackChanges) : IRequest<IEnumerable<CompanyDto>>;
}

using AutoMapper;
using CompanyEmployees.Application.Company.Queries;
using CompanyEmployees.Core.Domain.Repositories;
using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesQuery, IEnumerable<CompanyDto>>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCompaniesHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _repository.Company.GetAllCompaniesAsync(request.trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }
    }
}

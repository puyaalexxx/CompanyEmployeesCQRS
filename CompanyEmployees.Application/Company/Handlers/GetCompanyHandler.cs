using AutoMapper;
using CompanyEmployees.Application.Company.Queries;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public GetCompanyHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _repository.Company.GetCompanyAsync(request.Id, request.TrackChanges);

            if (company is null)
                throw new CompanyNotFoundException(request.Id);

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}

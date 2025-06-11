using AutoMapper;
using CompanyEmployees.Application.Company.Commands;
using CompanyEmployees.Core.Domain.Repositories;
using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDto>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CompanyDto> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            // Ensure the correct type for Company is used
            var companyEntity = _mapper.Map<CompanyEmployees.Core.Domain.Entities.Company>(request.Company);

            _repository.Company.CreateCompany(companyEntity);
            await _repository.SaveAsync(cancellationToken);

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }
    }
}

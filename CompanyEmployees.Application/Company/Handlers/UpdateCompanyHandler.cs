using AutoMapper;
using CompanyEmployees.Application.Company.Commands;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using MediatR;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _repository.Company.GetCompanyAsync(request.Id, request.TrackChanges);

            if (company is null)
                throw new CompanyNotFoundException(request.Id);

            _mapper.Map(request.Company, company);

            await _repository.SaveAsync(cancellationToken);
        }
    }
}

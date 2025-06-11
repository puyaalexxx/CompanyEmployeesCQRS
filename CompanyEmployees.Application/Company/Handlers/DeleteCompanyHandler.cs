using AutoMapper;
using CompanyEmployees.Application.Company.Notifications;
using CompanyEmployees.Core.Domain.Exceptions;
using CompanyEmployees.Core.Domain.Repositories;
using MediatR;

namespace CompanyEmployees.Application.Company.Handlers
{
    public class DeleteCompanyHandler : INotificationHandler<CompanyDeletedNotification>
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DeleteCompanyHandler(IMapper mapper, IRepositoryManager repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
        {
            var company = await _repository.Company.GetCompanyAsync(notification.id, notification.TrackChanges);

            if (company is null)
                throw new CompanyNotFoundException(notification.id);

            _repository.Company.DeleteCompany(company);

            await _repository.SaveAsync(cancellationToken);
        }
    }
}

using CompanyEmployees.Core.Domain.ContextFactory;
using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Infrastructure.Persistence.Repositories;

namespace CompanyEmployees.Infrastructure.Persistence
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICompanyRepository> _companyRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;

        public Task SaveAsync(CancellationToken ct = default) => _repositoryContext.SaveChangesAsync(ct);
    }
}
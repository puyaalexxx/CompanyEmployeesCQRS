using CompanyEmployees.Core.Domain.ContextFactory;

namespace CompanyEmployees.Core.Domain.Repositories;

public interface IRepositoryManager
{
    ICompanyRepository Company { get; }
    Task SaveAsync(CancellationToken ct = default);
}

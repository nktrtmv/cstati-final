using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts.Queries.GetAll;

namespace Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

public interface ICstatiAccountsRepository
{
    Task Upsert(CstatiAccount account, CancellationToken cancellationToken);
    Task Delete(string login, ConcurrencyToken concurrencyToken, CancellationToken cancellationToken);
    Task<CstatiAccount> GetRequired(string login, CancellationToken cancellationToken);
    Task<CstatiAccount[]> Get(string[] logins, CancellationToken cancellationToken);
    Task<CstatiAccount[]> GetAll(GetAllCstatiAccountsQuery query, CancellationToken cancellationToken);
}

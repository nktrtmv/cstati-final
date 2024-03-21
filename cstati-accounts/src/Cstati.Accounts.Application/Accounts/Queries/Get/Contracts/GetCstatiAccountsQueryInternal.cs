using MediatR;

namespace Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;

public sealed class GetCstatiAccountsQueryInternal : IRequest<GetCstatiAccountsQueryResponseInternal>
{
    public GetCstatiAccountsQueryInternal(string[] logins)
    {
        Logins = logins;
    }

    internal string[] Logins { get; }
}

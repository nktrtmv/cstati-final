using System.Text;
using System.Text.Json;

using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses;

namespace Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts;

internal static class CstatiAccountDbConverter
{
    internal static CstatiAccountDb FromDomain(CstatiAccount account)
    {
        string password = Password.Encrypt(account.Password);

        CstatiAccountAccessDb[] accesses = account.Accesses.Select(CstatiAccountAccessDbConverter.FromDomain).ToArray();

        string data = JsonSerializer.Serialize(accesses);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(account.ConcurrencyToken);

        var result = new CstatiAccountDb
        {
            Login = account.Login,
            Password = password,
            FullName = account.FullName,
            Data = data,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    internal static CstatiAccount ToDomain(CstatiAccountDb account)
    {
        string password = Password.Decrypt(account.Password);

        CstatiAccountAccessDb[] data = JsonSerializer.Deserialize<CstatiAccountAccessDb[]>(account.Data)!;

        CstatiAccountAccess[] accesses = data.Select(CstatiAccountAccessDbConverter.ToDomain).ToArray();

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromUnspecifiedUtcDateTime(account.ConcurrencyToken);

        var result = new CstatiAccount(account.Login, password, account.FullName, accesses, concurrencyToken);

        return result;
    }

    private static class Password
    {
        internal static string Encrypt(string password)
        {
            var result = new StringBuilder();

            foreach (char sym in password)
            {
                result.Append((int)sym + "-");
            }

            if (result.Length > 0)
            {
                result.Length--;
            }

            return result.ToString();
        }

        internal static string Decrypt(string password)
        {
            var result = new StringBuilder();

            string[] parts = password.Split('-');

            foreach (string part in parts)
            {
                int symCode = int.Parse(part);

                result.Append((char)symCode);
            }

            return result.ToString();
        }
    }
}

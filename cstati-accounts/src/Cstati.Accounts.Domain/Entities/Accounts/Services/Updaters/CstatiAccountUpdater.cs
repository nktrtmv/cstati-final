using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;

namespace Cstati.Accounts.Domain.Entities.Accounts.Services.Updaters;

public static class CstatiAccountUpdater
{
    public static void AddAccess(CstatiAccount account, CstatiAccountAccess access)
    {
        CstatiAccountAccess[] accesses = account.Accesses.Append(access).ToArray();

        account.SetAccesses(accesses);
    }

    public static void DeleteAccess(CstatiAccount account, CstatiAccountAccess access)
    {
        CstatiAccountAccess[] accesses = account.Accesses.Where(a => a != access).ToArray();

        account.SetAccesses(accesses);
    }
}

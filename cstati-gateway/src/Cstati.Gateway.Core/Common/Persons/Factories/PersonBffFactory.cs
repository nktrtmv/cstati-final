namespace Cstati.Gateway.Core.Common.Persons.Factories;

public static class PersonBffFactory
{
    public static PersonBff CreateNotEnriched(string login)
    {
        var result = new PersonBff
        {
            Login = login,
            FullName = string.Empty
        };

        return result;
    }
}

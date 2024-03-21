using System.Reflection;
using System.Text.Json.Serialization;

using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cstati.Gateway.GenericSubdomain.Swagger;

public static class SwaggerDerivedTypesConfiguration
{
    public static void ConfigureDerivedTypes(SwaggerGenOptions options)
    {
        options.UseOneOfForPolymorphism();

        options.SelectSubTypesUsing(
            subtype => subtype
                .GetCustomAttributes<JsonDerivedTypeAttribute>()
                .Select(attribute => attribute.DerivedType));

        options.SelectDiscriminatorNameUsing(_ => "$type");

        options.SelectDiscriminatorValueUsing(GetDiscriminatorValue);

        options.SchemaFilter<SwaggerConvertDiscriminatorsToEnumsSchemeFilter>();
    }

    private static string GetDiscriminatorValue(Type subType)
    {
        JsonDerivedTypeAttribute? attributeFromSameType = subType
            .GetCustomAttributes<JsonDerivedTypeAttribute>()
            .FirstOrDefault(x => x.DerivedType == subType);

        if (attributeFromSameType?.TypeDiscriminator is string typeDiscriminator)
        {
            return typeDiscriminator;
        }

        for (Type type = subType; type.BaseType is not null; type = type.BaseType)
        {
            JsonDerivedTypeAttribute? attribute = type.BaseType
                .GetCustomAttributes<JsonDerivedTypeAttribute>()
                .FirstOrDefault(x => x.DerivedType == subType);

            if (attribute?.TypeDiscriminator is string result)
            {
                return result;
            }
        }

        throw new InvalidOperationException($"Cannot determine value for subtype {subType}");
    }
}

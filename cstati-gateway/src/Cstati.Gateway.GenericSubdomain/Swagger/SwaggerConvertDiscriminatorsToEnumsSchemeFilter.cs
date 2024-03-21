using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cstati.Gateway.GenericSubdomain.Swagger;

internal sealed class SwaggerConvertDiscriminatorsToEnumsSchemeFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Discriminator is null)
        {
            return;
        }

        OpenApiSchema discriminatorSchema = CreateEnumForDiscriminator(schema, context);

        schema.Properties[schema.Discriminator.PropertyName] = discriminatorSchema;
    }

    private static OpenApiSchema CreateEnumForDiscriminator(OpenApiSchema schema, SchemaFilterContext context)
    {
        List<string> discriminatorKeys = schema
            .Discriminator
            .Mapping
            .Select(x => x.Key)
            .ToList();

        const string none = "None";

        if (!discriminatorKeys.Contains(none))
        {
            discriminatorKeys.Insert(0, none);
        }

        IEnumerable<OpenApiString> values =
            discriminatorKeys.Select(x => new OpenApiString(x));

        var enumSchema = new OpenApiSchema
        {
            Enum = new List<IOpenApiAny>(values)
        };

        OpenApiSchema? result = context.SchemaRepository.AddDefinition(
            context.Type.Name + "Type",
            enumSchema);

        return result;
    }
}

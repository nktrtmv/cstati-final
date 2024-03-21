using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace Cstati.Gateway.Presentation.Configuration;

internal static class ProblemDetailsConfiguration
{
    public static void Configure(ProblemDetailsOptions options)
    {
        options.IncludeExceptionDetails = (_, _) => true;

        options.MapToStatusCode<UnauthorizedAccessException>(StatusCodes.Status403Forbidden);
        options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);
        options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
    }
}

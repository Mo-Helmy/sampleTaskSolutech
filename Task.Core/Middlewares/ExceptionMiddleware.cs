using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Task.Core.Exceptions;
using Task.Core.Result;

namespace Task.Core.Middlewares;
public class ExceptionMiddleware : IExceptionHandler
{
    public ExceptionMiddleware()
    {
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionDetail = new ErrorClass(
            "Error",
            exception.Message,
            500);

        var errorDetail = Result<object>.IsFailure(exceptionDetail);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        if (exception is ValidationException validationException)
        {
            exceptionDetail = new ErrorClass("Error",
                    validationException.DisplayMessage,
                    validationException.MessageCode);

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            errorDetail = Result<object>.IsFailure(exceptionDetail);
        }

        else if (exception is BusinessRuleException business)
        {
            errorDetail = new ErrorClass(
                business.Message,
                "Not Found",
                100);
        }
        else if (exception is NotFoundException notFound)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            errorDetail = new ErrorClass(
               notFound.Message,
               "Not Found",
               404);
        }

        await httpContext.Response
            .WriteAsJsonAsync(errorDetail, cancellationToken);

        return true;
    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task.Core.Result;

namespace Task.Core.Middlewares;

public static class ValidationResponse
{
    public static IActionResult MakeValidationResponse(ActionContext context)
    {
        var respErrors = new List<ValidationError>();
        foreach (var keyModelStatePair in context.ModelState)
        {
            var errors = keyModelStatePair.Value.Errors;
            if (errors.Count <= 0) continue;
            var errorMessages = errors.Select(GetErrorMessage).ToList();
            var keyError = new ValidationError(keyModelStatePair.Key, errorMessages);
            respErrors.Add(keyError);
        }
        var errorDetail = new ErrorClass(respErrors);
        return new ObjectResult(errorDetail)
        {
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }

    private static string GetErrorMessage(ModelError error)
    {
        return string.IsNullOrEmpty(error.ErrorMessage) ? "The input was not valid." : error.ErrorMessage;
    }
}
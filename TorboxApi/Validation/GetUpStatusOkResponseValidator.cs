namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetUpStatusOkResponseValidator : AbstractValidator<GetUpStatusOkResponse?>
{
    public GetUpStatusOkResponseValidator() { }
}

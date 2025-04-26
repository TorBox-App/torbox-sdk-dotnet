namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetUsenetListOkResponseValidator : AbstractValidator<GetUsenetListOkResponse?>
{
    public GetUsenetListOkResponseValidator() { }
}

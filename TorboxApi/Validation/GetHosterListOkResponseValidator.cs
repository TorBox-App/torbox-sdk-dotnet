namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetHosterListOkResponseValidator : AbstractValidator<GetHosterListOkResponse?>
{
    public GetHosterListOkResponseValidator() { }
}

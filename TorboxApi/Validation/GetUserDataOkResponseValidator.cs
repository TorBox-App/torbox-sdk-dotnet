namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetUserDataOkResponseValidator : AbstractValidator<GetUserDataOkResponse?>
{
    public GetUserDataOkResponseValidator() { }
}

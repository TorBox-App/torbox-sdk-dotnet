namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetUserDataOkResponseDataValidator : AbstractValidator<GetUserDataOkResponseData?>
{
    public GetUserDataOkResponseDataValidator() { }
}

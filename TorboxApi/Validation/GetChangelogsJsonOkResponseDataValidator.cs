namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetChangelogsJsonOkResponseDataValidator
    : AbstractValidator<GetChangelogsJsonOkResponseData?>
{
    public GetChangelogsJsonOkResponseDataValidator() { }
}

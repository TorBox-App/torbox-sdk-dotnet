namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetChangelogsJsonOkResponseValidator : AbstractValidator<GetChangelogsJsonOkResponse?>
{
    public GetChangelogsJsonOkResponseValidator() { }
}

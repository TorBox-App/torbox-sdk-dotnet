namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateWebDownloadOkResponseValidator : AbstractValidator<CreateWebDownloadOkResponse?>
{
    public CreateWebDownloadOkResponseValidator() { }
}

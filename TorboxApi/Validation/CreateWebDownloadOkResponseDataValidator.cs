namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateWebDownloadOkResponseDataValidator
    : AbstractValidator<CreateWebDownloadOkResponseData?>
{
    public CreateWebDownloadOkResponseDataValidator() { }
}

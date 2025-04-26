namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateUsenetDownloadOkResponseDataValidator
    : AbstractValidator<CreateUsenetDownloadOkResponseData?>
{
    public CreateUsenetDownloadOkResponseDataValidator() { }
}

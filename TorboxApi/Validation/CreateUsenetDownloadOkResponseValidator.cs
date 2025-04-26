namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateUsenetDownloadOkResponseValidator
    : AbstractValidator<CreateUsenetDownloadOkResponse?>
{
    public CreateUsenetDownloadOkResponseValidator() { }
}

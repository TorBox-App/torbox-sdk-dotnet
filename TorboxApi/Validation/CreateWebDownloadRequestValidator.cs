namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateWebDownloadRequestValidator : AbstractValidator<CreateWebDownloadRequest?>
{
    public CreateWebDownloadRequestValidator() { }
}

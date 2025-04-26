namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateTorrentOkResponseDataValidator : AbstractValidator<CreateTorrentOkResponseData?>
{
    public CreateTorrentOkResponseDataValidator() { }
}

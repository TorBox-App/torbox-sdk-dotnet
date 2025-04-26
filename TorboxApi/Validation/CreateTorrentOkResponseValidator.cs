namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateTorrentOkResponseValidator : AbstractValidator<CreateTorrentOkResponse?>
{
    public CreateTorrentOkResponseValidator() { }
}

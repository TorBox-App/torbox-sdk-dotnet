namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class CreateTorrentRequestValidator : AbstractValidator<CreateTorrentRequest?>
{
    public CreateTorrentRequestValidator() { }
}

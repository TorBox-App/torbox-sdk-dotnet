namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class ControlTorrentOkResponseValidator : AbstractValidator<ControlTorrentOkResponse?>
{
    public ControlTorrentOkResponseValidator() { }
}

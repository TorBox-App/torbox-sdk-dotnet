namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class ExportTorrentDataOkResponseValidator : AbstractValidator<ExportTorrentDataOkResponse?>
{
    public ExportTorrentDataOkResponseValidator() { }
}

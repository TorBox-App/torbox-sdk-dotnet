namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentInfoOkResponseValidator : AbstractValidator<GetTorrentInfoOkResponse?>
{
    public GetTorrentInfoOkResponseValidator() { }
}

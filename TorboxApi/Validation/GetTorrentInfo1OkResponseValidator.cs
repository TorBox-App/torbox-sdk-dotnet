namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentInfo1OkResponseValidator : AbstractValidator<GetTorrentInfo1OkResponse?>
{
    public GetTorrentInfo1OkResponseValidator() { }
}

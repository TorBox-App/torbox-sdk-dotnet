namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentInfo1OkResponseDataValidator
    : AbstractValidator<GetTorrentInfo1OkResponseData?>
{
    public GetTorrentInfo1OkResponseDataValidator() { }
}

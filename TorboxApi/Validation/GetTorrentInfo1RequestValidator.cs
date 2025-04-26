namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentInfo1RequestValidator : AbstractValidator<GetTorrentInfo1Request?>
{
    public GetTorrentInfo1RequestValidator() { }
}

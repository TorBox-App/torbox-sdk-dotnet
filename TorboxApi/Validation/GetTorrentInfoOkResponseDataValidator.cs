namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentInfoOkResponseDataValidator
    : AbstractValidator<GetTorrentInfoOkResponseData?>
{
    public GetTorrentInfoOkResponseDataValidator() { }
}

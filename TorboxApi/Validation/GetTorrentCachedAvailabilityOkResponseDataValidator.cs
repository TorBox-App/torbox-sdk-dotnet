namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentCachedAvailabilityOkResponseDataValidator
    : AbstractValidator<GetTorrentCachedAvailabilityOkResponseData?>
{
    public GetTorrentCachedAvailabilityOkResponseDataValidator() { }
}

namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentCachedAvailabilityOkResponseValidator
    : AbstractValidator<GetTorrentCachedAvailabilityOkResponse?>
{
    public GetTorrentCachedAvailabilityOkResponseValidator() { }
}

namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class RequestDownloadLinkOkResponseValidator
    : AbstractValidator<RequestDownloadLinkOkResponse?>
{
    public RequestDownloadLinkOkResponseValidator() { }
}
